

using BakanasDigital.Think.Application.Interface;
using BakanasDigital.Think.Domain.Entities;
using BakanasDigital.Think.Domain.Interfaces.Services;
namespace BakanasDigital.Think.Application
{
    public class EnderecoInformacaoAppService : AppServiceBase<EnderecoInformacao>, IEnderecoInformacaoAppService
    {
        private readonly IEnderecoInformacaoService _service;

        public EnderecoInformacaoAppService(IEnderecoInformacaoService service)
            :base(service)
        {
            _service = service;
        }

        public EnderecoInformacao GetByClienteID(int p_ClienteID)
        {
            return _service.GetByClienteID(p_ClienteID);
        }

    }
}
