using BakanasDigital.Think.Application.Interface;
using BakanasDigital.Think.Domain.Entities;
using BakanasDigital.Think.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakanasDigital.Think.Application
{
    public class CartaoCreditoAppService : AppServiceBase<CartaoCredito>, ICartaoCreditoAppService
    {
        private readonly ICartaoCreditoService _Service;

        public CartaoCreditoAppService(ICartaoCreditoService service)
            :base(service)
        {
            _Service = service;
        }

    }
}
