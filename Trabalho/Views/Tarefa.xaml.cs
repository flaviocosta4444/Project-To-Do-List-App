using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Trabalho.Models;
using Trabalho.Views;

namespace Trabalho
{
    /// <summary>
    /// Lógica interna para Tarefa.xaml
    /// </summary>
    public partial class Tarefa : Window
    {
        public MainWindow _MainWindow;
        public Tarefa _Tarefa;
        public Tarefa(MainWindow mainWindow)
        {
            InitializeComponent();
            CarregarTarefas();
            _MainWindow = mainWindow;

        }

        private void btnCriarTarefa_Click(object sender, RoutedEventArgs e)
        {
            CriarTarefa criarTarefa = new CriarTarefa(this, _MainWindow);
            criarTarefa.ShowDialog();
        }        

        public void AdicionarTarefa(string nomeTarefa, string nivelImportancia, int nextId)
        {
            RadioButton radioButton = new RadioButton();
            radioButton.Content = nomeTarefa;
            radioButton.Tag = nextId;
            // Adicione o radioButton ao StackPanel apropriado (dependendo do grupo da tarefa)
            // Por exemplo, para adicionar ao primeiro grupo:
            // Adicione o radioButton ao StackPanel apropriado, com base no nível de importância
            switch (nivelImportancia)
            {
                case "Normal":
                    spNormais.Children.Add(radioButton);
                    break;
                case "Importante":
                    spImportantes.Children.Add(radioButton);
                    break;
                case "Prioritária":
                    spPrioritarias.Children.Add(radioButton);
                    break;
                case "Pouco Importante":
                    spPoucoImportantes.Children.Add(radioButton);
                    break;
            }
        }

        private void CarregarTarefas()
        {
            string diretorioAplicativo = AppDomain.CurrentDomain.BaseDirectory;
            string diretorioProjeto = Directory.GetParent(diretorioAplicativo).Parent.Parent.FullName;
            string nomeArquivo = "tarefas.txt";
            string caminhoArquivo = System.IO.Path.Combine(diretorioProjeto, nomeArquivo);

            if (File.Exists(caminhoArquivo))
            {
                string[] lines = File.ReadAllLines(caminhoArquivo);

                foreach (string linha in lines)
                {
                    string[] partes = linha.Split(',');
                    string id = "", titulo = "", importancia = "";

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
                                case "Importância":
                                    importancia = value;
                                    break;
                            }
                        }
                    }

                    if (int.TryParse(id, out int idInt))
                    {
                        AdicionarTarefa(titulo, importancia, idInt);
                    }
                }
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAbrirTarefa_Click(object sender, RoutedEventArgs e)
        {
            // Verifica qual radio button está selecionado em cada StackPanel
            RadioButton radioSelecionadoPoucoImportante = spPoucoImportantes.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
            RadioButton radioSelecionadoNormal = spNormais.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
            RadioButton radioSelecionadoImportante = spImportantes.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
            RadioButton radioSelecionadoPrioritarias = spPrioritarias.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);

            // Verifica se algum radio button está selecionado
            RadioButton radioSelecionado = radioSelecionadoPoucoImportante ?? radioSelecionadoNormal ?? radioSelecionadoImportante ?? radioSelecionadoPrioritarias;

            if (radioSelecionado != null)
            {
                // Obtém o conteúdo do radio button selecionado (que é o título da tarefa)
                string nomeTarefa = radioSelecionado.Content.ToString();

                // Obtém o ID da tarefa do Tag do radio button (assumindo que o ID foi definido como Tag)
                int nextId = (int)radioSelecionado.Tag;

                // Verifica em qual StackPanel o radio button está selecionado para passar a referência
                StackPanel parentStackPanel = null;
                if (radioSelecionadoNormal != null)
                {
                    parentStackPanel = spNormais;
                }
                else if (radioSelecionadoImportante != null)
                {
                    parentStackPanel = spImportantes;
                }
                else if (radioSelecionadoPrioritarias != null)
                {
                    parentStackPanel = spPrioritarias;
                }
                else if (radioSelecionadoPoucoImportante != null)
                {
                    parentStackPanel = spPoucoImportantes;
                }

                // Chama a função VisualizaçãoTarefa passando o nome da tarefa, o ID da tarefa, o StackPanel e o RadioButton
                VisualizaçãoTarefa(nomeTarefa, nextId, parentStackPanel, radioSelecionado);

                // Limpa a seleção do radio button
                radioSelecionado.IsChecked = false;
            }
            else
            {
                MessageBox.Show("Selecione uma tarefa para abrir.");
            }
        }


        public void VisualizaçãoTarefa(string nomeTarefa, int nextId, StackPanel stackPanel, RadioButton radioButton)
        {
            // Aqui você abre a nova visualização da tarefa passando a informação da tarefa selecionada
            AbrirTarefa abrirTarefa = new AbrirTarefa(nomeTarefa, nextId, stackPanel, radioButton, _MainWindow, _Tarefa);
            abrirTarefa.Show();
        }


        // Método para limpar a seleção de todos os RadioButtons em cada StackPanel
        private void LimparSelecaoRadioButtons()
        {
            foreach (RadioButton radioButton in spNormais.Children.OfType<RadioButton>())
            {
                radioButton.IsChecked = false;
            }

            foreach (RadioButton radioButton in spImportantes.Children.OfType<RadioButton>())
            {
                radioButton.IsChecked = false;
            }

            foreach (RadioButton radioButton in spPrioritarias.Children.OfType<RadioButton>())
            {
                radioButton.IsChecked = false;
            }
            foreach (RadioButton radioButton in spPoucoImportantes.Children.OfType<RadioButton>())
            {
                radioButton.IsChecked = false;
            }
        }
        private void btnLimparSeleção_Click(object sender, RoutedEventArgs e)
        {
            // Limpa a seleção de todos os RadioButtons em cada StackPanel
            LimparSelecaoRadioButtons();
        }

    }

}
