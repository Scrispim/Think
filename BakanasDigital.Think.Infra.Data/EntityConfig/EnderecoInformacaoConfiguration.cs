

using BakanasDigital.Think.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
namespace BakanasDigital.Think.Infra.Data.EntityConfig
{
    public class EnderecoInformacaoConfiguration : EntityTypeConfiguration<EnderecoInformacao>
    {
        public EnderecoInformacaoConfiguration()
        {
            HasKey(c => c.EnderecoInformacaoID);

            Property(c => c.TotalComodo)
                .IsRequired();

            Property(c => c.TotalBanheiro)
                .IsRequired();

            Property(c => c.TotalMetragem)
                .IsRequired();

            Property(c => c.AreaLazer)
                .IsRequired();

            Property(c => c.Empregada)
                .IsRequired();

            Property(c => c.TotalPessoa)
                .IsRequired();

            Property(c => c.TotalIdoso)
                .IsRequired();

            Property(c => c.TotalCrianca)
                .IsRequired();

            Property(c => c.Animal)
                .IsRequired();

            Property(c => c.AnimalTipo)
                .HasMaxLength(1000)
                .IsRequired();

            Property(c => c.AnimalNome)
                .HasMaxLength(1000)
                .IsRequired();

            Property(c => c.PrestacaoServicoHorario)
                .HasMaxLength(500)
                .IsRequired();

            Property(c => c.CuidadoEspecial)
                .HasMaxLength(1000)
                .IsRequired();

            Property(c => c.InformacaoResidencia)
                .HasMaxLength(1000)
                .IsRequired();

            Property(c => c.ClienteID)
                .IsRequired();

        }
    }
}
