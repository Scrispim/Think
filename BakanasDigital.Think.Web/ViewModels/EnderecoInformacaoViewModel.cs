using BakanasDigital.Think.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BakanasDigital.Think.Web.ViewModels
{
    public class EnderecoInformacaoViewModel
    {
        [Key]
        public int EnderecoInformacaoID { get; set; }

        [Required(ErrorMessage = "Preencha o campo quantidade de cômodos.")]
        [DisplayName("Quantas cômodos tem essa casa (exceto banheiros)?")]
        public int TotalComodo { get; set; }

        [Required(ErrorMessage = "Preencha o campo quantidade de banheiros.")]
        [DisplayName("Quantos banheiros? ")]
        public int TotalBanheiro { get; set; }

        [Required(ErrorMessage = "Preencha o campo metragem.")]
        [DisplayName("Qual a metragem total?")]
        public float TotalMetragem { get; set; }

        [Required(ErrorMessage = "Preencha o campo área de lazer externa.")]
        [DisplayName("Possui área de lazer externa?")]
        public bool AreaLazer { get; set; }

        [Required(ErrorMessage = "Preencha o campo se você tem empregada nessa casa.")]
        [DisplayName("Você tem empregada nessa casa?")]
        public bool Empregada { get; set; }

        [Required(ErrorMessage = "Preencha o campo Quantas pessoas vivem nessa casa.")]
        [DisplayName("Quantas pessoas vivem nessa casa? ")]
        public int TotalPessoa { get; set; }

        [Required(ErrorMessage = "Preencha o campo Quantos idosos.")]
        [DisplayName("idosos - Quantos?")]
        public int TotalIdoso { get; set; }

        [Required(ErrorMessage = "Preencha o campo Quantas crianças.")]
        [DisplayName("crianças - Quantas? ")]
        public int TotalCrianca { get; set; }

        [Required(ErrorMessage = "Preencha o campo Tem animais de estimação.")]
        [DisplayName("Tem animais de estimação?")]
        public bool Animal { get; set; }

        [Required(ErrorMessage = "Preencha o campo Tem animais de estimação.")]
        [DisplayName("Quais animais?")]
        public string AnimalTipo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Quais os nomes deles.")]
        [DisplayName("Quais os nomes deles?")]
        public string AnimalNome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Quais você considera os melhores horários para prestação dos nossos serviços nessa casa.")]
        [DisplayName("Quais você considera os melhores horários para prestação dos nossos serviços nessa casa?")]
        public string PrestacaoServicoHorario { get; set; }

        [Required(ErrorMessage = "Preencha o campo Alguma parte da sua casa precisa de cuidados especiais (cômodos que não devem ser acessados, objetos com defeitos, tomadas com voltagem 220w, vazamentos, etc).")]
        [DisplayName("Alguma parte da sua casa precisa de cuidados especiais (cômodos que não devem ser acessados, objetos com defeitos, tomadas com voltagem 220w, vazamentos, etc)?")]
        public string CuidadoEspecial { get; set; }

        [Required(ErrorMessage = "Preencha o campo Existe alguma coisa mais que você deseja nos falar sobre essa residência.")]
        [DisplayName("Existe alguma coisa mais que você deseja nos falar sobre essa residência?")]
        public string InformacaoResidencia { get; set; }

        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}