using Logstore.Domain.LogStoreContext.Entities;
using Logstore.Domain.LogStoreContext.Repositories.Interfaces;
using Logstore.Infra.Context;

namespace Logstore.Infra.Repositorys
{
    public class ProdutoPedidoRepository : BaseRepository<ProdutoPedido>, IProdutoPedidoRepository
    {
        
        private readonly LogStoreContext _context;
        public ProdutoPedidoRepository(LogStoreContext context) : base(context)
        {
            _context = context;
        }
    }
}