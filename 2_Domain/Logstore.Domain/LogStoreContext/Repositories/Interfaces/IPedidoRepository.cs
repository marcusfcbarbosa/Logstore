using System.Collections.Generic;
using System.Threading.Tasks;
using Logstore.Domain.LogStoreContext.Entities;

namespace Logstore.Domain.LogStoreContext.Repositories.Interfaces
{
    public interface IPedidoRepository : IBaseRepository<Pedido>
    {
         List<Pedido> BuscaPedidosPorCliente(string email);
    }
}