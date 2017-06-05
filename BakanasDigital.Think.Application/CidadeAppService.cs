using BakanasDigital.Think.Application.Interface;
using BakanasDigital.Think.Domain.Entities;
using BakanasDigital.Think.Domain.Interfaces.Services;

namespace BakanasDigital.Think.Application
{
    public class CidadeAppService : AppServiceBase<Cidade>, ICidadeAppService
    {
        private readonly ICidadeService _Service;

        public CidadeAppService(ICidadeService service)
            :base(service)
        {
            _Service = service;
        }
    }
}
