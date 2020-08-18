using System.Threading.Tasks;
using Logstore.Domain.LogStoreContext.Entities;

namespace Logstore.Domain.LogStoreContext.Repositories.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
         Task<Cliente> RetornaClientePorEmail(string email);
    }
}