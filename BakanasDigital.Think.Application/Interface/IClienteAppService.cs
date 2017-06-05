using BakanasDigital.Think.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakanasDigital.Think.Application.Interface
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        //IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes);
    }
}
