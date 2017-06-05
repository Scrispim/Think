using BakanasDigital.Think.Application.Interface;
using BakanasDigital.Think.Domain.Entities;
using BakanasDigital.Think.Domain.Interfaces.Services;

namespace BakanasDigital.Think.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _clienteService;
        public ClienteAppService(IClienteService clienteService)
            :base(clienteService)
        {
            _clienteService = clienteService;
        }

        //public IEnumerable<Cliente> ObterClientesEspeciais()
        //{
        //    return _clienteService.ObterClientesEspeciais(_clienteService.GetAll());
        //}
    }
}
