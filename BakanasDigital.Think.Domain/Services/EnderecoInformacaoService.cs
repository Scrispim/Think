

using BakanasDigital.Think.Domain.Entities;
using BakanasDigital.Think.Domain.Interfaces.Repositories;
using BakanasDigital.Think.Domain.Interfaces.Services;
namespace BakanasDigital.Think.Domain.Services
{
    public class EnderecoInformacaoService : ServiceBase<EnderecoInformacao>, IEnderecoInformacaoService
    {
        private readonly IEnderecoInformacaoRepository _repository;

        public EnderecoInformacaoService(IEnderecoInformacaoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public EnderecoInformacao GetByClienteID(int p_ClienteID)
        {
            return _repository.GetByClienteID(p_ClienteID);
        }

    }
}
