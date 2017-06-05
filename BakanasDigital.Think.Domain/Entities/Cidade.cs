using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakanasDigital.Think.Domain.Entities
{
    public class Cidade
    {
        public int CidadeID { get; set; }        
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
