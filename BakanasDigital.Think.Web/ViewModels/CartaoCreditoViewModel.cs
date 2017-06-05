using BakanasDigital.Think.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace BakanasDigital.Think.Web.ViewModels
{
    public class CartaoCreditoViewModel
    {
        [Key]
        public int CartaoCreditoID { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string CodigoSeguranca { get; set; }
        public DateTime DataValidade { get; set; }
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}