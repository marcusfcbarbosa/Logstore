using System.Collections.Generic;
using System.Threading.Tasks;
using Logstore.Domain.LogStoreContext.Entities;

namespace Logstore.Domain.LogStoreContext.Repositories.Interfaces
{
    public interface IPedidoRepository : IBaseRepository<Pedido>
    {
         Task<List<Pedido>> BuscaPedidosPorCliente(string email);
    }
}