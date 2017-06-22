

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BakanasDigital.Think.Web.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Sobrenome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo telefone fixo")]
        [MaxLength(15, ErrorMessage = "Máximo {0} caracteres")]
        [Phone(ErrorMessage = "Preencha um número válido")]
        [DisplayName("Telefone fixo")]
        public string TelefoneFixo { get; set; }

        [Required(ErrorMessage = "Preencha o campo telefone celular")]
        [MaxLength(15, ErrorMessage = "Máximo {0} caracteres")]
        [Phone(ErrorMessage = "Preencha um número válido")]
        [DisplayName("Telefone celular")]
        public string TelefoneCelular { get; set; }

        [Required(ErrorMessage = "Preencha o campo data de nascimento")]
        [DisplayName("Data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Preencha o campo número identidade")]
        [DisplayName("Número Identidade")]
        public string NumeroIdentidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo orgão emissor")]
        [DisplayName("Orgão Emissor")]
        public string OrgaoEmissor { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cpf")]
        [DisplayName("CPF")]        
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Preencha o campo Genero")]
        [DisplayName("Gênero")]
        public int GeneroID { get; set; }
        
        [Required(ErrorMessage = "Preencha o campo como gostaria de ser tratado")]
        [DisplayName("Como gostaria de ser tratado(a)?")]
        public int ComoSerTratadoID { get; set; }

        [Required(ErrorMessage = "Preencha o campo como gostaria de ser tratado descrição")]
        [DisplayName("Descrição?")]
        public string ComoSerTratadoDescricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo como CEP")]
        [DisplayName("CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Preencha o campo Endereço")]
        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Preencha o campo Número")]
        [DisplayName("Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Preencha o campo Complemento")]
        [DisplayName("Complemento")]
        public int ComplementoID { get; set; }

        [Required(ErrorMessage = "Preencha o campo Bairro")]
        [DisplayName("Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [DisplayName("Cidade")]
        public int CidadeID { get; set; }
        public virtual CidadeViewModel Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo Estado")]
        [DisplayName("Estado")]
        public int EstadoID { get; set; }
        public virtual EstadoViewModel Estado { get; set; }


        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}