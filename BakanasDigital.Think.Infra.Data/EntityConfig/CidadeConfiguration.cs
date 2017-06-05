using BakanasDigital.Think.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakanasDigital.Think.Infra.Data.EntityConfig
{
    public class CidadeConfiguration : EntityTypeConfiguration<Cidade>
    {
        public CidadeConfiguration()
        {
            HasKey(c => c.CidadeID);

            Property(c => c.Descricao)
                .HasMaxLength(500)
                .IsRequired();

            Property(c => c.EstadoID)
                .IsRequired();
            
        }
    }
}
