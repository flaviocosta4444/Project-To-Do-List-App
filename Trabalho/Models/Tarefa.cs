using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_software.Modelos;

namespace Trabalho.Models
{
    class Tarefa
    {
        //Atributos
        public int Id { get; set; }
        public string Título { get; set; }
        public string Descrição { get; set; }
        public DateTime DataInício { get; set; }
        public DateTime DataTérmino { get; set; }
        public string NívelImportância { get; set; }
        public string Estado { get; set; }
        public Periodicidade Periodicidade { get; set; }
        public AlertaModel AlertaAntecipação { get; set; }
        public AlertaModel AlertaExecução { get; set; }





    }

        

}


