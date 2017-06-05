using BakanasDigital.Think.Application.Interface;
using BakanasDigital.Think.Domain.Entities;
using BakanasDigital.Think.Domain.Interfaces.Services;

namespace BakanasDigital.Think.Application
{
    public class EstadoAppService  : AppServiceBase<Estado>, IEstadoAppService
    {
        private readonly IEstadoService _Service;
        public EstadoAppService(IEstadoService service)
            : base(service)
        {
            _Service = service;
        }
    }
}
