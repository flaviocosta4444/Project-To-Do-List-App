using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Trabalho.Views;

namespace Trabalho
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tb_data.Text = DateTime.Now.ToString("dd/MM/yyyy");
            CarregarTarefasDoDia();
        }

        private void CarregarTarefasDoDia()
        {
            string diretorioAplicativo = AppDomain.CurrentDomain.BaseDirectory;
            string diretorioProjeto = Directory.GetParent(diretorioAplicativo).Parent.Parent.FullName;
            string nomeArquivo = "tarefas.txt";
            string caminhoArquivo = System.IO.Path.Combine(diretorioProjeto, nomeArquivo);

            if (File.Exists(caminhoArquivo))
            {
                string dataHoje = DateTime.Now.ToString("dd/MM/yyyy");
                string[] lines = File.ReadAllLines(caminhoArquivo);

                foreach (string linha in lines)
                {
                    string[] partes = linha.Split(',');
                    string id = "", titulo = "", data = "", importancia = "";

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
                                    data = value;
                                    break;
                                case "Importância":
                                    importancia = value;
                                    break;
                            }
                        }
                    }

                    if (DateTime.TryParse(data, out DateTime dataTarefa))
                    {
                        if (dataTarefa.ToString("dd/MM/yyyy") == dataHoje)
                        {
                            RadioButton radioButton = new RadioButton
                            {
                                Content = titulo,
                                Tag = int.TryParse(id, out int idInt) ? idInt : (int?)null
                            };

                            spTarefasDoDia.Children.Add(radioButton);
                        }
                    }
                }
            }
        }
        private void BtnTarefas_Click(object sender, RoutedEventArgs e)
        {
            Tarefa tarefaWindow = new Tarefa(this);
            tarefaWindow.ShowDialog();
            
        }

        public void AdicionarTarefaDoDia(string titulo, int id)
        {
            RadioButton radioButton = new RadioButton
            {
                Content = titulo,
                Tag = id
            };

            spTarefasDoDia.Children.Add(radioButton);
        }

        public void RemoverTarefaDoDia(int id)
        {
            // Encontra o RadioButton com o ID especificado no StackPanel
            RadioButton radioButtonToRemove = null;
            foreach (UIElement child in spTarefasDoDia.Children)
            {
                if (child is RadioButton rb && (int)rb.Tag == id)
                {
                    radioButtonToRemove = rb;
                    break;
                }
            }

            if (radioButtonToRemove != null)
            {
                // Remove o RadioButton do StackPanel
                spTarefasDoDia.Children.Remove(radioButtonToRemove);
            }
        }

        private void BtnPerfil_Click(object sender, RoutedEventArgs e)
        {
            Perfil perfil = new Perfil();
            perfil.ShowDialog();
        }

        private void BtnCalendario_Click(object sender, RoutedEventArgs e)
        {
            VerTarefas vertarefas = new VerTarefas();
            vertarefas.ShowDialog();
        }

        private void BtnAdicionarAlerta_Click(object sender, RoutedEventArgs e)
        {
            Alerta alerta = new Alerta();
            alerta.ShowDialog();
        }

        private void BtnConcluir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
