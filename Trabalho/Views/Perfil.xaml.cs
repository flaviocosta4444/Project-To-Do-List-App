using Microsoft.Win32;
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
using System.Windows.Shapes;
using System.Configuration;
using System.Windows;

namespace Trabalho.Views
{
    /// <summary>
    /// Lógica interna para Perfil.xaml
    /// </summary>
    public partial class Perfil : Window
    {
        private App _app;
        public Perfil()
        {
            InitializeComponent();

            _app = App.Current as App;
            _app.ViewModel.PerfilFotoCarregada += ViewModel_PerfilFotoCarregada;
            _app.ViewModel.PerfilFotoGuardada += ViewModel_PerfilFotoGuardada;
            txtNome.Text = Properties.Settings.Default.Nome;
            txtEmail.Text = Properties.Settings.Default.Email;
            
            string imgPath = Properties.Settings.Default.Img;
            if (!string.IsNullOrEmpty(imgPath))
            {
                try
                {
                    imgFotografia.Source = new BitmapImage(new Uri(imgPath, UriKind.RelativeOrAbsolute));
                }
                catch (UriFormatException ex)
                {
                    MessageBox.Show($"Erro ao carregar imagem: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void ViewModel_PerfilFotoGuardada()
        {
            MessageBox.Show("Fotografia atualizada com sucesso!", "Fotografia", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ViewModel_PerfilFotoCarregada()
        {
            tbNomeFicheiro.Text = _app.ViewModel.MyPerfilFoto.Ficheiro;
            imgFotografia.Source = _app.ViewModel.MyPerfilFoto.Fotografia;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Imagens JPG|*.jpg|Imagens PNG|*.png|Todos os ficheiros|*.*";

            if (dlg.ShowDialog() == true)
            {
                //_app.ViewModel.SaveToTXT(dlg.FileName);
                _app.ViewModel.SaveToXML(dlg.FileName);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //_app.ViewModel.LoadFromTXT("dados.txt");
            _app.ViewModel.LoadFromXML("dados.xml");

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            BitmapImage foto = imgFotografia.Source as BitmapImage;

            if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(email))
            {
                // Guardar os valores nas configurações do aplicativo
                Properties.Settings.Default.Nome = nome;
                Properties.Settings.Default.Email = email;
                Properties.Settings.Default.Img = foto.UriSource.ToString();
                Properties.Settings.Default.Save();

                MessageBox.Show("Perfil guardado com sucesso!");
            }
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string userName = Environment.UserName;
        }

            private void txtNome_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
