using BakanasDigital.Think.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakanasDigital.Think.Infra.Data.EntityConfig
{
    public class CartaoCreditoConfiguration : EntityTypeConfiguration<CartaoCredito>
    {
        public CartaoCreditoConfiguration()
        {
            HasKey(c => c.CartaoCreditoID);

            Property(c => c.Nome)
                .HasMaxLength(500)
                .IsRequired();

            Property(c => c.Numero)
                .HasMaxLength(20)
                .IsRequired();

            Property(c => c.CodigoSeguranca)
                .HasMaxLength(5)
                .IsRequired();

            Property(c => c.DataValidade)
                .IsRequired();

            Property(c => c.ClienteID)
                .IsRequired();

        }
    }
}
