using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakanasDigital.Think.Domain.Entities
{
    public class EnderecoInformacao
    {
        public int EnderecoInformacaoID { get; set; }
        public int TotalComodo { get; set; }
        public int TotalBanheiro { get; set; }
        public float TotalMetragem { get; set; }
        public bool AreaLazer { get; set; }
        public bool Empregada { get; set; }
        public int TotalPessoa { get; set; }
        public int TotalIdoso { get; set; }
        public int TotalCrianca { get; set; }
        public bool Animal { get; set; }
        public string AnimalTipo { get; set; }
        public string AnimalNome { get; set; }
        public string PrestacaoServicoHorario { get; set; }
        public string CuidadoEspecial { get; set; }
        public string InformacaoResidencia { get; set; }
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
