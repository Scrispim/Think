using BakanasDigital.Think.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakanasDigital.Think.Infra.Data.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.ClienteID);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Sobrenome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.TelefoneFixo)
                .HasMaxLength(15)
                .IsRequired();

            Property(c => c.TelefoneCelular)
                .HasMaxLength(15)
               .IsRequired();

            Property(c => c.DataNascimento)
               .IsRequired();

            Property(c => c.NumeroIdentidade)
                .HasMaxLength(15)
               .IsRequired();

            Property(c => c.OrgaoEmissor)
                .HasMaxLength(500)
               .IsRequired();

            Property(c => c.Cpf)
                .HasMaxLength(20)
                .IsRequired();

            Property(c => c.Email)
                .IsRequired();

            Property(c => c.GeneroID)
                .IsRequired();

            Property(c => c.ComoSerTratadoID)
                .IsOptional();

            Property(c => c.ComoSerTratadoDescricao)
                .HasMaxLength(500)
                .IsOptional();

            Property(c => c.Cep)
               .HasMaxLength(15)
               .IsOptional();

            Property(c => c.Endereco)
               .HasMaxLength(500)
               .IsOptional();

            Property(c => c.Numero)
               .HasMaxLength(500)
               .IsOptional();

            Property(c => c.ComplementoID)
               .IsOptional();

            Property(c => c.Bairro)
               .HasMaxLength(500)
               .IsOptional();

            Property(c => c.CidadeID)
               .IsOptional();

            Property(c => c.EstadoID)
               .IsOptional();

        }
    }
}
