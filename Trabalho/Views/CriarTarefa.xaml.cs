using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Trabalho.Models;
using Trabalho_software.Modelos;

namespace Trabalho.Views
{
    /// <summary>
    /// Lógica interna para CriarTarefa.xaml
    /// </summary>
    public partial class CriarTarefa : Window
    {
        public Tarefa _Tarefa;
        public MainWindow _MainWindow;
        AlertaModel alerta = new AlertaModel();
        public CriarTarefa(Tarefa tarefa, MainWindow mainWindow)
        {
            InitializeComponent();
            _Tarefa = tarefa;
            _MainWindow = mainWindow;
            this.Loaded += Alerta_Loaded;
        }

        private void Alerta_Loaded(object sender, RoutedEventArgs e)
        {
            tempo_label.Visibility = Visibility.Collapsed;

            label_horas.Visibility = Visibility.Collapsed;
            label_min.Visibility = Visibility.Collapsed;
            tempo_minutos.Visibility = Visibility.Collapsed;
            tempo_tb.Visibility = Visibility.Collapsed;
        }
        private int ObterId()
        {
            string diretorioAplicativo = AppDomain.CurrentDomain.BaseDirectory;
            string diretorioProjeto = Directory.GetParent(diretorioAplicativo).Parent.Parent.FullName;
            string nomeArquivo = "tarefas.txt";
            string caminhoArquivo = System.IO.Path.Combine(diretorioProjeto, nomeArquivo);

            if (!File.Exists(caminhoArquivo))
            {
                return 1;
            }

            string lastLine = File.ReadLines(caminhoArquivo).LastOrDefault();
            if (lastLine == null)
            {
                return 1;
            }

            string[] parts = lastLine.Split(',');
            string idPart = parts.FirstOrDefault(p => p.Trim().StartsWith("ID:"));
            if (idPart == null)
            {
                return 1;
            }

            string idString = idPart.Split(':')[1].Trim();
            if (int.TryParse(idString, out int lastId))
            {
                return lastId + 1;
            }

            return 1;
        }

        private void btnCriar_Click(object sender, RoutedEventArgs e)

        {
            // Obtendo os dados dos controles da interface do usuário
            int nextId = ObterId();
            string titulo = txtTitulo.Text;
            string descrição = txtDescricao.Text;
            
            string importancia = cbNivelDeImportancia.Text;
            string repetir = cbRepetir.Text;
            string datainicio = dpDataInicio.SelectedDate.Value.ToString("dd/MM/yyyy");
            string datafim = dpDataFim.SelectedDate.Value.ToString("dd/MM/yyyy");
            string id_tarefa = nextId.ToString();
            string estado = string.Empty;
            string nomeTarefa = titulo; // Aqui você pode definir o nome da tarefa
            string nivelImportancia = ((ComboBoxItem)cbNivelDeImportancia.SelectedItem).Content.ToString();
            _Tarefa.AdicionarTarefa(nomeTarefa, nivelImportancia, nextId);

            // Determinar o estado da tarefa com base na data atual
            DateTime datainicial = DateTime.Parse(dpDataInicio.SelectedDate.Value.ToString("dd/MM/yyyy"));
            DateTime datafinal = DateTime.Parse(dpDataFim.SelectedDate.Value.ToString("dd/MM/yyyy"));
            DateTime dataAtual = DateTime.Now;
            if (datainicial > dataAtual)
            {
                estado = "Por iniciar";
            }

            // Montando a string que representa a tarefa
            string tarefa = $"ID:{id_tarefa}, Título: {titulo}, Data Início: {datainicio}, Data Fim: {datafim}, Descrição: {descrição}, Importância: {importancia}, Repetir: {repetir}, Estado: {estado} ";


            // Obtenha o caminho do diretório de saída do aplicativo
            string diretorioAplicativo = AppDomain.CurrentDomain.BaseDirectory;

            // Obtenha o diretório do projeto (assumindo que está dois níveis acima do diretório bin/Debug ou bin/Release)
            string diretorioProjeto = Directory.GetParent(diretorioAplicativo).Parent.Parent.FullName;

            // Defina o nome do arquivo
            string nomeArquivo = "tarefas.txt";

            // Combine o caminho do diretório do projeto com o nome do arquivo
            string caminhoArquivo = System.IO.Path.Combine(diretorioProjeto, nomeArquivo);

            // Escrevendo a tarefa no arquivo de texto
            try
            {
                using (StreamWriter writer = new StreamWriter(caminhoArquivo, true))
                {
                    writer.WriteLine(tarefa);
                    //verifica se o arquivo existe
                    if (!File.Exists(caminhoArquivo))
                    {
                        //cria o arquivo
                        File.Create(caminhoArquivo);
                    }
                }
                // Se a data da tarefa for hoje, adicione ao StackPanel na MainWindow
                if (datainicio == DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    _MainWindow.AdicionarTarefaDoDia(titulo, nextId);
                }
                MessageBox.Show("Tarefa criada e salva com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao salvar a tarefa: {ex.Message}");
            }
            

            if (A_cb.IsChecked == true)
            {
                int tempo_h = Convert.ToInt32(tempo_tb.Text);
                int tempo_m = Convert.ToInt32(tempo_tb.Text);
                DateTime horaAlertaA = DateTime.MinValue;
                DateTime horaAlertaN = DateTime.MinValue;
                alerta.AlertaAntecipacao(descrição, id_tarefa, tempo_h, tempo_m);
            }
            if (Nr.IsChecked == true)
            {
               alerta.AlertaNaoRealizacao(descrição, id_tarefa);
            }
        }

        private void txtDescricao_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void cbNivelDeImportancia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbNivelDeImportancia.SelectedIndex == 0)
            {
                A_cb.IsChecked = true;
                Nr.IsChecked = true;
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

       

        private void Oi(object sender, RoutedEventArgs e)
        {

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

        
    


