

using BakanasDigital.Think.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
namespace BakanasDigital.Think.Infra.Data.EntityConfig
{
    public class EnderecoInformacaoConfiguration : EntityTypeConfiguration<EnderecoInformacao>
    {
        public EnderecoInformacaoConfiguration()
        {
            HasKey(c => c.Endereco_InformacaoID);

            Property(c => c.Total_Comodo)
                .IsRequired();

            Property(c => c.Total_Banheiro)
                .IsRequired();

            Property(c => c.Total_Metragem)
                .IsRequired();

            Property(c => c.Area_Lazer)
                .IsRequired();

            Property(c => c.Empregada)
                .IsRequired();

            Property(c => c.Total_Pessoa)
                .IsRequired();

            Property(c => c.Total_Idoso)
                .IsRequired();

            Property(c => c.Total_Crianca)
                .IsRequired();

            Property(c => c.Animal)
                .IsRequired();

            Property(c => c.Animal_Tipo)
                .HasMaxLength(1000)
                .IsRequired();

            Property(c => c.Animal_Nome)
                .HasMaxLength(1000)
                .IsRequired();

            Property(c => c.Prestacao_Servico_Horario)
                .HasMaxLength(500)
                .IsRequired();

            Property(c => c.Cuidado_Especial)
                .HasMaxLength(1000)
                .IsRequired();

            Property(c => c.Informacao_Residencia)
                .HasMaxLength(1000)
                .IsRequired();

        }
    }
}
