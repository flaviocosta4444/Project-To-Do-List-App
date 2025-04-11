using System;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using Windows.Phone.Notification.Management;
using Trabalho_software.Modelos;
using System.ComponentModel;
namespace Trabalho.Views

{
    /// <summary>
    /// Lógica interna para Alerta.xaml
    /// </summary>
    public partial class Alerta : Window
    {
        public Alerta()
        {

            InitializeComponent();
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
    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Você pode adicionar lógica aqui, se necessário
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Você pode adicionar lógica aqui, se necessário
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AlertaModel alerta = new AlertaModel();
            string idtarefa1 = ID_Alerta_tb.Text;
            string descricao = Descricao_tb.Text;
            int tempo_h = Convert.ToInt32(tempo_tb.Text);
            int tempo_m = Convert.ToInt32(tempo_tb.Text);
            DateTime horaAlertaA = DateTime.MinValue;
            DateTime horaAlertaN = DateTime.MinValue;
            alerta.EscreverAlerta(descricao, idtarefa1, horaAlertaA, horaAlertaN);
            

            if (Email_cb.IsChecked == true)
                {
                    alerta.EnviarEmail(descricao, idtarefa1);
                }
            if (Windows_cb.IsChecked == true)
                {
                    alerta.EnviarNotificacao(descricao, idtarefa1);
                }
            if (Antecipacao_cb.IsChecked == true)
            {
                   alerta.AlertaAntecipacao(descricao, idtarefa1, tempo_h,tempo_m);
                }
            if (NaoRealizacao_cb.IsChecked == true)
            {
                alerta.AlertaNaoRealizacao(descricao, idtarefa1);

            }

           
            

        }

        private void Email_check(object sender, RoutedEventArgs e)
        {

        }

        private void Antecipação(object sender, RoutedEventArgs e)
        {
            tempo_label.Visibility = Visibility.Visible;

            label_horas.Visibility = Visibility.Visible;
            label_min.Visibility = Visibility.Visible;
            tempo_minutos.Visibility = Visibility.Visible;
            tempo_tb.Visibility = Visibility.Visible;

        }

        private void Windows_check(object sender, RoutedEventArgs e)
        {

        }

        private void NaoRealizacao_check(object sender, RoutedEventArgs e)
        {

        }

        private void ID_Alerta_tb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Antecipacao_unchecked(object sender, RoutedEventArgs e)
        {
            tempo_label.Visibility = Visibility.Collapsed;

            label_horas.Visibility = Visibility.Collapsed;
            label_min.Visibility = Visibility.Collapsed;
            tempo_minutos.Visibility = Visibility.Collapsed;
            tempo_tb.Visibility = Visibility.Collapsed;

        }
    }
    
}
