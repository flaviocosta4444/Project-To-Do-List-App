using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;
using System.IO;
using Trabalho.Views;
using System.Windows.Navigation;
using Windows.UI.Xaml.Input;

namespace Trabalho_software.Modelos
{
    class AlertaModel
    {
        // Atributos
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public int Data_hora { get; set; }
        public string Tipos { get; set; }
        public bool Desligado { get; set; }

        string titulo;
        //private static async Task VerificarEEnviarEmail()
        //{
        //    string caminhoArquivo = "Caminho\\Para\\SeuArquivo\\Alertas.txt"; // Substitua pelo caminho real do seu arquivo txt

        //    if (!File.Exists(caminhoArquivo))
        //    {
        //        Console.WriteLine("Arquivo não encontrado.");
        //        return;
        //    }

        //    string diretorioAplicativo = AppDomain.CurrentDomain.BaseDirectory;
        //    string diretorioProjeto = Directory.GetParent(diretorioAplicativo).Parent.Parent.FullName;
        //    string nomeArquivo = "Alertas.txt";
        //    string caminhoArquivo1 = System.IO.Path.Combine(diretorioProjeto, nomeArquivo);
        //    using (StreamReader sr = File.OpenText(caminhoArquivo1))
        //    {
        //        string linha;
        //        while ((linha = sr.ReadLine()) != null)
        //        {
        //            string[] partes = linha.Split(',');

        //            if (partes.Length >= 4 &&
        //                                       DateTime.TryParse(partes[3].Split(':')[1].Trim(), out DateTime dataHoraAlertaA))
        //            {
        //                if (dataHoraAlertaA <= DateTime.Now && dataHoraAlertaA > DateTime.Now.AddMinutes(-1))
        //                {
        //                    // Envia o e-mail se a data e hora corresponder ao horário atual
        //                    EnviarEmail(partes[2].Split(':')[1].Trim());
        //                }
        //            }

        //            if (partes.Length >= 5 &&
        //                                       DateTime.TryParse(partes[4].Split(':')[1].Trim(), out DateTime dataHoraAlertaN))
        //            {
        //                if (dataHoraAlertaN <= DateTime.Now && dataHoraAlertaN > DateTime.Now.AddMinutes(-1))
        //                {
        //                    // Envia o e-mail se a data e hora corresponder ao horário atual
        //                    EnviarEmail(partes[2].Split(':')[1].Trim());
        //                }
        //            }
        //        }
        //    }
        //}
        public void EnviarEmail(string descricao, string idtarefa1)
        {
         int nextid=Convert.ToInt32(idtarefa1);
            CarregarInformacoes(nextid, out string id, out string titulo1, out string datainicio, out string datafim, out string descricao1, out string alerta, out string importancia, out string repetir, out string estado);

            titulo = titulo1;
           

           
          
            string fromMail = "todolist3322@gmail.com";
            string fromPassword = "urpd ncrl jgll jkyz";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = titulo1;
            string emailperfil = Trabalho.Properties.Settings.Default.Email;
            message.To.Add(new MailAddress(emailperfil));
            message.Body = $"<html><body> {descricao} </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
        }

        public void CarregarInformacoes(int nextId, out string id, out string titulo, out string datainicio, out string datafim, out string descricao, out string alerta, out string importancia, out string repetir, out string estado)
        {
            // Inicializa as variáveis de saída
            id = ""; titulo = ""; datainicio = ""; datafim = ""; descricao = ""; alerta = ""; importancia = ""; repetir = ""; estado = "";

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

                    // Inicializa variáveis temporárias para cada linha
                    string tempId = "", tempTitulo = "", tempDataInicio = "", tempDataFim = "", tempDescricao = "", tempAlerta = "", tempImportancia = "", tempRepetir = "", tempEstado = "";

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
                                    tempId = value;
                                    break;
                                case "Título":
                                    tempTitulo = value;
                                    break;
                                case "Data Início":
                                    tempDataInicio = value;
                                    break;
                                case "Data Fim":
                                    tempDataFim = value;
                                    break;
                                case "Descrição":
                                    tempDescricao = value;
                                    break;
                                case "Alerta":
                                    tempAlerta = value;
                                    break;
                                case "Importância":
                                    tempImportancia = value;
                                    break;
                                case "Repetir":
                                    tempRepetir = value;
                                    break;
                                case "Estado":
                                    tempEstado = value;
                                    break;
                            }
                        }
                    }

                    // Verifica se o ID da tarefa corresponde ao nextId
                    if (tempId == nextId.ToString())
                    {
                        // Atribui os valores encontrados às variáveis de saída
                        id = tempId;
                        titulo = tempTitulo;
                        datainicio = tempDataInicio;
                        datafim = tempDataFim;
                        descricao = tempDescricao;
                        alerta = tempAlerta;
                        importancia = tempImportancia;
                        repetir = tempRepetir;
                        estado = tempEstado;
                        break;
                    }
                }
            }
        }


        public void EnviarNotificacao(string descricao, string idtarefa1)
        {
            string titulo1 = "";
            string diretorioAplicativo = AppDomain.CurrentDomain.BaseDirectory;
            string diretorioProjeto = Directory.GetParent(diretorioAplicativo).Parent.Parent.FullName;
            string nomeArquivo = "tarefas.txt";
            string caminhoArquivo = System.IO.Path.Combine(diretorioProjeto, nomeArquivo);
            string[] lines = File.ReadAllLines(caminhoArquivo);
            foreach (string linha in lines)
            {
                string[] partes = linha.Split(',');
                string id = "", titulo = "";
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
                            case "Titulo":
                                titulo = value;
                                break;
                        }
                    }
                }
                if (id == idtarefa1)
                {
                    titulo1 = titulo;
                    break;
                }
            }
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText(titulo1)
                .AddText(descricao)
                .Show();
        }

        private int ObterId()
        {
            try
            {
                string diretorioAplicativo = AppDomain.CurrentDomain.BaseDirectory;
                string diretorioProjeto = Directory.GetParent(diretorioAplicativo)?.Parent?.Parent?.FullName;
                using (System.IO.StreamReader reader = new System.IO.StreamReader("tarefas.txt"))
                {
                    if (diretorioProjeto == null)
                    {
                        Console.WriteLine("Erro: Não foi possível determinar o diretório do projeto.");
                        return 1;
                    }

                    string nomeArquivo1 = "Alertas.txt";
                    string caminhoArquivo1 = Path.Combine(diretorioProjeto, nomeArquivo1);

                    if (!File.Exists(caminhoArquivo1))
                    {
                        Console.WriteLine($"Arquivo {caminhoArquivo1} não encontrado. Retornando ID = 1.");
                        return 1;
                    }

                    string lastLine = File.ReadLines(caminhoArquivo1).LastOrDefault();

                    if (string.IsNullOrEmpty(lastLine))
                    {
                        Console.WriteLine("Arquivo vazio. Retornando ID = 1.");
                        return 1;
                    }

                    string[] parts = lastLine.Split(',');
                    string idPart = parts.FirstOrDefault(p => p.Trim().StartsWith("ID:"));

                    if (idPart == null)
                    {
                        Console.WriteLine("Nenhuma parte contendo 'ID:' encontrada. Retornando ID = 1.");
                        return 1;
                    }

                    string idString = idPart.Split(':')[1].Trim();
                    if (int.TryParse(idString, out int lastId))
                    {
                        return lastId + 1;
                    }

                    Console.WriteLine("Falha ao analisar o ID. Retornando ID = 1.");
                    return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter ID: {ex.Message}");
                return 1;
            }
        
        }


        public void EscreverAlerta(string descricao, string idtarefa1,DateTime horaAlertaA, DateTime horaAlertaN)
        {
          int nextid=Convert.ToInt32(idtarefa1);
            CarregarInformacoes(nextid, out string id, out string titulo1, out string datainicio, out string datafim, out string descricao1, out string alerta, out string importancia, out string repetir, out string estado);

            int id_alerta = ObterId();
            Convert.ToString(id_alerta);
            string diretorioAplicativo1 = AppDomain.CurrentDomain.BaseDirectory;
            string diretorioProjeto1 = Directory.GetParent(diretorioAplicativo1).Parent.Parent.FullName;
            string nomeArquivo1 = "Alertas.txt";
            string caminhoArquivo1 = Path.Combine(diretorioProjeto1, nomeArquivo1);

            try
            {
                Console.WriteLine($"Caminho do arquivo: {caminhoArquivo1}");

                
                    
                    string alerta1 = $"ID: {id_alerta}, IDT: {idtarefa1}, Descricao: {descricao}, DataHoraAlertaA: {horaAlertaA}, DataHoraAlertaN: {horaAlertaN}";
                    using (StreamWriter sw = File.AppendText(caminhoArquivo1))
                    {
                        sw.WriteLine(alerta1);
                    }   
                    Console.WriteLine($"Alerta escrito no arquivo");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao escrever : {ex.Message}");
            }
        }


        public void AlertaAntecipacao(string descricao, string idtarefa1, int tempo_h, int tempo_m)
        {
           

            int nextid = Convert.ToInt32(idtarefa1);
            CarregarInformacoes(nextid, out string id, out string titulo, out string datainicio, out string datafim, out string descricao1, out string alerta, out string importancia, out string repetir, out string estado);
            
         
            DateTime horaAlertaA = DateTime.MinValue; // Inicializando a hora do alerta como mínimo
            string[] formatosPermitidos = { "yyyy-MM-dd HH:mm", "yyyy-MM-ddTHH:mm:ss", "dd/MM/yyyy HH:mm", "dd-MM-yyyy HH:mm","dd/MM/yyyy" };
            if (!DateTime.TryParseExact(datainicio, formatosPermitidos, null, System.Globalization.DateTimeStyles.None, out DateTime datainicio1))
            {
                
                Console.WriteLine("Erro ao converter a data de início.");
                return;
            }
            else
            {
                Console.WriteLine($"Data de início: {datainicio1}");
            }
            horaAlertaA = datainicio1.AddHours(-tempo_h).AddMinutes(-tempo_m); // Calcula a hora do alerta
            DateTime horaAlertaN = DateTime.MinValue;
            EscreverAlerta(descricao, idtarefa1, horaAlertaA, horaAlertaN);
            

        }





        public void AlertaNaoRealizacao(string descricao, string idtarefa1)
        {

            
            int nextid=Convert.ToInt32(idtarefa1);
            CarregarInformacoes(nextid, out string id, out string titulo, out string datainicio, out string datafim, out string descricao1, out string alerta, out string importancia, out string repetir, out string estado);
            DateTime horaAlertaN = DateTime.MinValue; // Inicializando a hora do alerta como mínimo
            string[] formatosPermitidos = { "yyyy-MM-dd HH:mm", "yyyy-MM-ddTHH:mm:ss", "dd/MM/yyyy HH:mm", "dd-MM-yyyy HH:mm", "dd/MM/yyyy" };
            if (!DateTime.TryParseExact(datafim, formatosPermitidos, null, System.Globalization.DateTimeStyles.None, out DateTime datafim1))
            {
                Console.WriteLine("Erro ao converter a data de início.");
                return;
            }
            else
            {
                Console.WriteLine($"Data e fim: {datafim1}");
            }
            horaAlertaN = datafim1; // Calcula a hora do alerta
            DateTime horaAlertaA=DateTime.MinValue;
            EscreverAlerta(descricao, idtarefa1, horaAlertaA, horaAlertaN);
        }

    }
}

