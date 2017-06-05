using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BakanasDigital.Think.Web.ViewModels
{
    public class CidadeViewModel
    {
        [Key]
        public int CidadeId { get; set; }

        
        public string Descricao { get; set; }

        public string EstadoID { get; set; }

        public virtual EstadoViewModel Estado { get; set; }

        public bool Ativo { get; set; }
    }
}