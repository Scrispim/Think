
using System;
using System.Collections;
namespace BakanasDigital.Think.Domain.Entities
{
    public class CartaoCredito
    {
        public int CartaoCreditoID { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string CodigoSeguranca { get; set; }
        public DateTime DataValidade { get; set; }
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }

        //public IEnumerable<CartaoCredito> GetByClienteID(int p_ClienteID)
        //{
        //    return t //cliente.m_Ativo && DateTime.Now.Year - cliente.m_DataCadastro.Year >= 5;
        //}
    }
}
