using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Trabalho.Models;
using Windows.UI.Xaml.Controls;
using Trabalho_software.Modelos;
using System.Runtime.InteropServices.ComTypes;

namespace Trabalho.Views
{
    /// <summary>
    /// Lógica interna para AbrirTarefa.xaml
    /// </summary>
    public partial class AbrirTarefa : Window
    {
        public int IDdesejado;
        public System.Windows.Controls.StackPanel parentStackPanel;
        public System.Windows.Controls.RadioButton associatedRadioButton;
        public MainWindow _MainWindow;
        public Tarefa _Tarefa; 
        AlertaModel alerta = new AlertaModel();

        
       

     
        public AbrirTarefa(string nomeTarefa, int nextId, System.Windows.Controls.StackPanel stackPanel, System.Windows.Controls.RadioButton radioButton, MainWindow mainWindow, Tarefa tarefa)
        {
            InitializeComponent();
            CarregarInformacoes(nextId);
            IDdesejado = nextId;
            parentStackPanel = stackPanel;
            associatedRadioButton = radioButton;
            _MainWindow = mainWindow;
            btnGuardar.Visibility = Visibility.Collapsed;
            this.Loaded += Alerta_Loaded;
        }
        private void Alerta_Loaded(object sender, RoutedEventArgs e)
        {
            tempo_label.Visibility = Visibility.Collapsed;

            label_horas.Visibility = Visibility.Collapsed;
            label_min.Visibility = Visibility.Collapsed;
            tempo_minutos.Visibility = Visibility.Collapsed;
            tempo_tb.Visibility = Visibility.Collapsed;
            A_cb.IsEnabled = false;
            Nr.IsEnabled = false;
        }

        private void CarregarInformacoes(int nextId)
        {
            string diretorioAplicativo = AppDomain.CurrentDomain.BaseDirectory;
            string diretorioProjeto = Directory.GetParent(diretorioAplicativo).Parent.Parent.FullName;
            string nomeArquivo = "tarefas.txt";
            string caminhoArquivo = System.IO.Path.Combine(diretorioProjeto, nomeArquivo);

            if (File.Exists(caminhoArquivo))
            {
                bool tarefaEncontrada = false;
                string[] lines = File.ReadAllLines(caminhoArquivo);

                foreach (string linha in lines)
                {
                    string[] partes = linha.Split(',');
                    string id = "", titulo = "", datainicio = "", datafim = "", descricao = "", alerta = "", importancia = "", repetir = "", estado = "";

                    foreach (string parte in partes)
                    {
                        string[] keyValue = parte.Split(new[] { ':' }, 2);
                        if (keyValue.Length == 2)
                        {
                            string key = keyValue[0].Trim();
                            string value = keyValue[1].Trim();

                            switch (key)
                            {
                                case "ID":
                                    id = value;
                                    break;
                                case "Título":
                                    titulo = value;
                                    break;
                                case "Data Início":
                                    datainicio = value;
                                    break;
                                case "Data Fim":
                                    datafim = value;
                                    break;
                                case "Descrição":
                                    descricao = value;
                                    break;
                                case "Alerta":
                                    alerta = value;
                                    break;
                                case "Importância":
                                    importancia = value;
                                    break;
                                case "Repetir":
                                    repetir = value;
                                    break;
                                case "Estado":
                                    estado = value;
                                    break;
                            }
                        }
                    }

                    // Verifica se o ID corresponde ao desejado
                    // Convertendo o ID para int e verificando se corresponde ao desejado
                    int idInt;
                    if (int.TryParse(id, out idInt) && idInt == nextId)
                    {
                        tarefaEncontrada = true;
                        txtID.Text = id;
                        txtTitulo.Text = titulo;
                        dpDataInicio.Text = datainicio;
                        dpDataFim.Text = datafim;
                        txtDescricao.Text = descricao;
                       
                        cbNivelDeImportancia.Items.Add(importancia);
                        cbNivelDeImportancia.SelectedItem = importancia;
                        cbRepetir.Items.Add(repetir);
                        cbRepetir.SelectedItem = repetir;
                        txtEstado.Text = estado;

                        break; // Encerra o loop ao encontrar a tarefa correta
                    }
                    
                }

                if (!tarefaEncontrada)
                {
                    MessageBox.Show("Tarefa não encontrada.");
                }
            }
            else
            {
                MessageBox.Show("Ficheiro não encontrado.");
            }

        }

        private bool isEditing = false;
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            btnGuardar.Visibility = Visibility.Visible;

            // Verifica se está no modo de edição
            if (!isEditing)
            {
                // Habilita os campos para edição
                txtTitulo.IsEnabled = true;
                txtDescricao.IsEnabled = true;
               
                cbNivelDeImportancia.IsEnabled = true;
                cbRepetir.IsEnabled = true;
                dpDataInicio.IsEnabled = true;
                dpDataFim.IsEnabled = true;
                A_cb.IsEnabled = true;
                Nr.IsEnabled = true;
                isEditing = true;

            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            // Obtém os novos valores das TextBoxes
            string id = txtID.Text;
            string novoTitulo = txtTitulo.Text;
            string novaDescrição = txtDescricao.Text;
            
            string novaImportancia = cbNivelDeImportancia.Text;
            string novoRepetir = cbRepetir.Text;
            string novoDataInicio = dpDataInicio.SelectedDate.Value.ToString("dd/MM/yyyy");
            string novoDataFim = dpDataFim.SelectedDate.Value.ToString("dd/MM/yyyy");
            string estado = txtEstado.Text;          

            // Atualiza a tarefa com os novos valores
            AtualizarTarefa(id, novoTitulo, novaDescrição, novaImportancia, novoRepetir, novoDataInicio, novoDataFim, estado);

            if (A_cb.IsChecked == true)
            {
                int tempo_h = Convert.ToInt32(tempo_tb.Text);
                int tempo_m = Convert.ToInt32(tempo_tb.Text);
                DateTime horaAlertaA = DateTime.MinValue;
                DateTime horaAlertaN = DateTime.MinValue;

                alerta.AlertaAntecipacao("", id, tempo_h, tempo_m);
            }
            if (Nr.IsChecked == true)
            {
                alerta.AlertaNaoRealizacao("", id);
            }
        }
    

        private void AtualizarTarefa(string id, string novoTitulo, string novaDescrição, string novaImportancia, string novoRepetir, string novoDataInicio, string novoDataFim, string estado)
        {
            string diretorioAplicativo = AppDomain.CurrentDomain.BaseDirectory;
            string diretorioProjeto = Directory.GetParent(diretorioAplicativo).Parent.Parent.FullName;
            string nomeArquivo = "tarefas.txt";
            string caminhoArquivo = System.IO.Path.Combine(diretorioProjeto, nomeArquivo);

            // Montando a string que representa a tarefa
            string novaTarefa = $"ID:{id}, Título: {novoTitulo}, Data Início: {novoDataInicio}, Data Fim: {novoDataFim}, Descrição: {novaDescrição}, Importância: {novaImportancia}, Repetir: {novoRepetir}, Estado: {estado} ";

            // Verificando se o arquivo existe
            if (!File.Exists(caminhoArquivo))
            {
                MessageBox.Show("O arquivo de tarefas não foi encontrado.");
                return;
            }

            // Lendo todas as linhas do arquivo de texto
            string[] linhas = File.ReadAllLines(caminhoArquivo);

            // Encontrando a linha com a tarefa que está sendo editada
            int index = -1;
            for (int i = 0; i < linhas.Length; i++)
            {
                if (linhas[i].StartsWith($"ID:{id},"))
                {
                    index = i;
                    break;
                }
            }

            // Atualiza ou adiciona a tarefa conforme necessário
            if (index != -1)
            {
                // Atualizando a linha antiga com os dados novos
                linhas[index] = novaTarefa;
            }
            else
            {
                // Adicionando a nova tarefa ao final da lista de linhas
                var listaLinhas = linhas.ToList();
                listaLinhas.Add(novaTarefa);
                linhas = listaLinhas.ToArray();
            }

            // Escrevendo todas as linhas (incluindo a tarefa atualizada) de volta ao arquivo
            File.WriteAllLines(caminhoArquivo, linhas);

            MessageBox.Show("Tarefa atualizada com sucesso!");
            this.Close();
        }

        private void btnConcluir_Click(object sender, RoutedEventArgs e)
        {
            string diretorioAplicativo = AppDomain.CurrentDomain.BaseDirectory;
            string diretorioProjeto = Directory.GetParent(diretorioAplicativo).Parent.Parent.FullName;
            string nomeArquivo = "tarefas.txt";
            string caminhoArquivo = System.IO.Path.Combine(diretorioProjeto, nomeArquivo);

            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);
                bool tarefaEncontrada = false;

                for (int i = 0; i < linhas.Length; i++)
                {
                    string[] partes = linhas[i].Split(',');

                    // Verifica se a linha tem a quantidade esperada de partes e se o ID corresponde
                    if (partes.Length > 0 && partes[0].Trim() == $"ID:{IDdesejado}")
                    {
                        // Atualiza o campo do Estado para "Concluída"
                        for (int j = 0; j < partes.Length; j++)
                        {
                            string[] keyValue = partes[j].Split(new[] { ':' }, 2);
                            if (keyValue.Length == 2 && keyValue[0].Trim() == "Estado")
                            {
                                partes[j] = " Estado: Concluída";
                                tarefaEncontrada = true;
                                break;
                            }
                        }

                        // Atualiza a linha modificada
                        linhas[i] = string.Join(",", partes);
                        this.Close();
                        break;
                    }
                }

                if (tarefaEncontrada)
                {
                    File.WriteAllLines(caminhoArquivo, linhas);
                    MessageBox.Show("Tarefa concluída com sucesso!");
                    txtEstado.Text = "Concluída";  // Atualiza o campo de texto na UI
                }
                else
                {
                    MessageBox.Show("Tarefa não encontrada.");
                }
            }
            else
            {
                MessageBox.Show("Ficheiro não encontrado.");
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string diretorioAplicativo = AppDomain.CurrentDomain.BaseDirectory;
            string diretorioProjeto = Directory.GetParent(diretorioAplicativo).Parent.Parent.FullName;
            string nomeArquivo = "tarefas.txt";
            string caminhoArquivo = System.IO.Path.Combine(diretorioProjeto, nomeArquivo);

            if (File.Exists(caminhoArquivo))
            {
                var lines = File.ReadAllLines(caminhoArquivo).ToList();
                bool tarefaEncontrada = false;
                // Verifica se a data da tarefa é igual à data atual
                string dataHoje = DateTime.Now.ToString("dd/MM/yyyy");

                for (int i = 0; i < lines.Count; i++)
                {
                    string linha = lines[i];
                    string[] partes = linha.Split(',');
                    if (partes.Length > 0 && partes[0].Trim() == $"ID:{IDdesejado}")
                    {
                        // Verifica se a data da tarefa é igual à data atual
                        if (partes.Length > 2 && partes[2].Trim() == $"Data Início: {dataHoje}")
                        {
                            // Remove o RadioButton correspondente do StackPanel na MainWindow
                            _MainWindow.RemoverTarefaDoDia(IDdesejado);
                        }

                        tarefaEncontrada = true;
                        lines.RemoveAt(i);
                        break;
                    }
                }

                if (tarefaEncontrada)
                {
                    File.WriteAllLines(caminhoArquivo, lines);
                    MessageBox.Show("Tarefa eliminada com sucesso!");
                    // Remove o RadioButton associado do StackPanel
                    if (parentStackPanel != null && associatedRadioButton != null)
                    {
                        parentStackPanel.Children.Remove(associatedRadioButton);
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao encontrar a tarefa para eliminar.");
                }
            }
            else
            {
                MessageBox.Show("Ficheiro não encontrado.");
            }
        }

        private void A_cb_check(object sender, RoutedEventArgs e)
        {
            tempo_label.Visibility = Visibility.Visible;

            label_horas.Visibility = Visibility.Visible;
            label_min.Visibility = Visibility.Visible;
            tempo_minutos.Visibility = Visibility.Visible;
            tempo_tb.Visibility = Visibility.Visible;
        }
        private void A_cb_un(object sender, RoutedEventArgs e)
        {
            tempo_label.Visibility = Visibility.Collapsed;

            label_horas.Visibility = Visibility.Collapsed;
            label_min.Visibility = Visibility.Collapsed;
            tempo_minutos.Visibility = Visibility.Collapsed;
            tempo_tb.Visibility = Visibility.Collapsed;
        }
    }

}
