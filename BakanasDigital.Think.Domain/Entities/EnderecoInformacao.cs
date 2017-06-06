using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakanasDigital.Think.Domain.Entities
{
    public class EnderecoInformacao
    {
        public int Endereco_InformacaoID { get; set; }
        public int Total_Comodo { get; set; }
        public int Total_Banheiro { get; set; }
        public float Total_Metragem { get; set; }
        public bool Area_Lazer { get; set; }
        public bool Empregada { get; set; }
        public int Total_Pessoa { get; set; }
        public int Total_Idoso { get; set; }
        public int Total_Crianca { get; set; }
        public bool Animal { get; set; }
        public string Animal_Tipo { get; set; }
        public string Animal_Nome { get; set; }
        public string Prestacao_Servico_Horario { get; set; }
        public string Cuidado_Especial { get; set; }
        public string Informacao_Residencia { get; set; }
    }
}
