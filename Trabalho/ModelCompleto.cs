using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using Trabalho.Models;

namespace Trabalho
{
    public class ModelCompleto
    {
        public PerfilFoto MyPerfilFoto { get; private set; } = new PerfilFoto();

        public event MetodosSemParametros PerfilFotoCarregada;
        public event MetodosSemParametros PerfilFotoGuardada;

        private string _caminhoBase;
        private string _caminhoTotal;
        private string _caminhoFotos;

        public ModelCompleto()
        {
            _caminhoBase = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (Directory.Exists(System.IO.Path.Combine(_caminhoBase, "MyApp")) == false)
            {
                Directory.CreateDirectory(System.IO.Path.Combine(_caminhoBase, "MyApp"));
            }
            _caminhoTotal = System.IO.Path.Combine(_caminhoBase, "MyApp");

            if (Directory.Exists(System.IO.Path.Combine(_caminhoTotal, "Fotos")) == false)
            {
                Directory.CreateDirectory(System.IO.Path.Combine(_caminhoTotal, "Fotos"));
            }

            _caminhoFotos = System.IO.Path.Combine(_caminhoTotal, "Fotos");
        }

        public void LoadFromTXT(string ficheiro)
        {
            if (File.Exists(System.IO.Path.Combine(_caminhoTotal, ficheiro)) != false)
            {
                string nomeFoto = File.ReadAllText(System.IO.Path.Combine(_caminhoTotal, "dados.txt"));
                var uri = new Uri(System.IO.Path.Combine(_caminhoFotos, nomeFoto));
                MyPerfilFoto.Fotografia = new BitmapImage(uri);
                MyPerfilFoto.Fotografia.Freeze();

                MyPerfilFoto.Ficheiro = ficheiro;
            }
            else
            {
                _LoadSemFoto();
            }

            if (PerfilFotoCarregada != null)
            {
                PerfilFotoCarregada();
            }
        }


        public void LoadFromXML(string ficheiro)
        {
            if (File.Exists(System.IO.Path.Combine(_caminhoTotal, ficheiro)) != false)
            {
                XDocument doc = XDocument.Load(System.IO.Path.Combine(_caminhoTotal, "dados.xml"));
                string nomeFoto = doc.Element("perfil").Attribute("fotografia").Value;

                var uri = new Uri(System.IO.Path.Combine(_caminhoFotos, nomeFoto));
                MyPerfilFoto.Fotografia = new BitmapImage(uri);
                MyPerfilFoto.Fotografia.Freeze();

                MyPerfilFoto.Ficheiro = ficheiro;
            }
            else
            {
                _LoadSemFoto();
            }

            if (PerfilFotoCarregada != null)
            {
                PerfilFotoCarregada();
            }
        }

        public void SaveToXML(string ficheiro)
        {
            string NomeFoto = System.IO.Path.GetFileName(ficheiro);
            File.Copy(ficheiro, System.IO.Path.Combine(_caminhoFotos, NomeFoto), true);

            XDocument doc = new XDocument();
            doc.Add(new XElement("perfil", new XAttribute("fotografia", NomeFoto)));
            doc.Save(System.IO.Path.Combine(_caminhoTotal, "dados.xml"));

            LoadFromXML("dados.xml");

            if (PerfilFotoGuardada != null)
            {
                PerfilFotoGuardada();
            }
        }

        private void _LoadSemFoto()
        {
            var uri = new Uri("pack://application:,,,/Fotos/noPhoto.jpg");
            MyPerfilFoto.Fotografia = new BitmapImage(uri);
            MyPerfilFoto.Fotografia.Freeze();

            MyPerfilFoto.Ficheiro = "[sem foto]";
        }
    }
}

