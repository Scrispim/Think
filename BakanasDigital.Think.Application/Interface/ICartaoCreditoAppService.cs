using BakanasDigital.Think.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakanasDigital.Think.Application.Interface
{
    public interface ICartaoCreditoAppService : IAppServiceBase<CartaoCredito>
    {
        IEnumerable<CartaoCredito> GetByClienteID(int p_ClienteID);
    }
}
