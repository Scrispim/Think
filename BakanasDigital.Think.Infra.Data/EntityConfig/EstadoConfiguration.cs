using BakanasDigital.Think.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakanasDigital.Think.Infra.Data.EntityConfig
{
    public class EstadoConfiguration : EntityTypeConfiguration<Estado>
    {
        public EstadoConfiguration()
        {
            HasKey(c => c.EstadoID);

            Property(c => c.Descricao)
                .HasMaxLength(500)
                .IsRequired();

            Property(c => c.Sigla)
                .HasMaxLength(5)
                .IsRequired();
            
        }
    }
}
