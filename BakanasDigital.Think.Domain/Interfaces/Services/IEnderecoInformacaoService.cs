

using BakanasDigital.Think.Domain.Entities;
namespace BakanasDigital.Think.Domain.Interfaces.Services
{
    public interface IEnderecoInformacaoService : IServiceBase<EnderecoInformacao>
    {
        EnderecoInformacao GetByClienteID(int p_ClienteID);
    }
}
