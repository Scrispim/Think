using BakanasDigital.Think.Domain.Entities;
using BakanasDigital.Think.Domain.Interfaces.Repositories;
using BakanasDigital.Think.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakanasDigital.Think.Domain.Services
{
    public class CartaoCreditoService : ServiceBase<CartaoCredito>, ICartaoCreditoService
    {
        private readonly ICartaoCreditoRepository _Repository;

        public CartaoCreditoService(ICartaoCreditoRepository repository)
            : base(repository)
        {
            _Repository = repository;
        }

    }
}
