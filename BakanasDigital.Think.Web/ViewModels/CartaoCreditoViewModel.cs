using BakanasDigital.Think.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BakanasDigital.Think.Web.ViewModels
{
    public class CartaoCreditoViewModel
    {
        [Key]
        public int CartaoCreditoID { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome escrito no cartão")]
        [DisplayName("Nome escrito no cartão")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo número")]
        [DisplayName("Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Preencha o campo código de segurança")]
        [DisplayName("Código de segurança")]
        public string CodigoSeguranca { get; set; }

        [Required(ErrorMessage = "Preencha o campo data de validade")]
        [DisplayName("Data validade")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataValidade { get; set; }
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}