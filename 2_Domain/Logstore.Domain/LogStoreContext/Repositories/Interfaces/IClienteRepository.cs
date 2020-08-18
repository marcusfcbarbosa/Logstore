using System.Threading.Tasks;
using Logstore.Domain.LogStoreContext.Entities;

namespace Logstore.Domain.LogStoreContext.Repositories.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
         Cliente RetornaClientePorEmail(string email);
    }
}