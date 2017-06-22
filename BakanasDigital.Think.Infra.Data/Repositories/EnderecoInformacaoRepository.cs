

using BakanasDigital.Think.Domain.Entities;
using BakanasDigital.Think.Domain.Interfaces.Repositories;
using System.Linq;

namespace BakanasDigital.Think.Infra.Data.Repositories
{
    public class EnderecoInformacaoRepository : RepositoryBase<EnderecoInformacao>, IEnderecoInformacaoRepository
    {
        public EnderecoInformacao GetByClienteID(int p_ClienteID)
        {
            return Db.EnderecoInformacoes.Where(x => x.ClienteID == p_ClienteID).FirstOrDefault();
        }
    }
}
