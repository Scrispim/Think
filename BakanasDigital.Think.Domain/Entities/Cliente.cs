
using System;
namespace BakanasDigital.Think.Domain.Entities
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneCelular { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroIdentidade { get; set; }
        public string OrgaoEmissor { get; set; }
        public string Cpf { get; set; }
        public int GeneroID { get; set; }
        public int? ComoSerTratadoID { get; set; }
        public string ComoSerTratadoDescricao { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public int ComplementoID { get; set; }
        public string Bairro { get; set; }
        public int CidadeID { get; set; }
        public virtual Cidade Cidade { get; set; }
        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        //public bool m_Ativo { get; set; }

        //public bool ClienteEspecial(Cliente cliente)
        //{
        //    return cliente.m_Ativo && DateTime.Now.Year - cliente.m_DataCadastro.Year >= 5;
        //}
    }
}
