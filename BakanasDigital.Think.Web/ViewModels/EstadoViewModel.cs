using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BakanasDigital.Think.Web.ViewModels
{
    public class EstadoViewModel
    {
        [Key]
        public int EstadoId { get; set; }

        public string Descricao { get; set; }

        public string Sigla { get; set; }
        public bool Ativo { get; set; }
    }
}