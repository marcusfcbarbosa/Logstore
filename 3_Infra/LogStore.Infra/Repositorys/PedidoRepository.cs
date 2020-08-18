using Logstore.Domain.LogStoreContext.Entities;
using Logstore.Domain.LogStoreContext.Repositories.Interfaces;
using Logstore.Infra.Context;

namespace Logstore.Infra.Repositorys
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly LogStoreContext _context;
        public PedidoRepository(LogStoreContext context) : base(context)
        {
            _context = context;
        }
    }
}