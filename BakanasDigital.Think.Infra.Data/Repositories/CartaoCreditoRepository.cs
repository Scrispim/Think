using BakanasDigital.Think.Domain.Entities;
using BakanasDigital.Think.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BakanasDigital.Think.Infra.Data.Repositories
{
    public class CartaoCreditoRepository : RepositoryBase<CartaoCredito>, ICartaoCreditoRepository
    {
        public IEnumerable<CartaoCredito> GetByClienteID(int p_ClienteID)
        {
            return Db.CartaoCreditos.Where(x => x.ClienteID == p_ClienteID);
        }
    }
}
