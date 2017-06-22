using BakanasDigital.Think.Domain.Entities;

namespace BakanasDigital.Think.Domain.Interfaces.Repositories
{
    public interface IEnderecoInformacaoRepository : IRepositoryBase<EnderecoInformacao>
    {
        EnderecoInformacao GetByClienteID(int p_ClienteID);
    }
}
