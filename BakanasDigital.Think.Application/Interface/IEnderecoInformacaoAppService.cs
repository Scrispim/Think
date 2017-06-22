

using BakanasDigital.Think.Domain.Entities;
namespace BakanasDigital.Think.Application.Interface
{
    public interface IEnderecoInformacaoAppService : IAppServiceBase<EnderecoInformacao>
    {
        EnderecoInformacao GetByClienteID(int p_ClienteID);
    }
}
