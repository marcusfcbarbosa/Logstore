using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logstore.Domain.LogStoreContext.Entities;
using Logstore.Domain.LogStoreContext.Repositories.Interfaces;
using Logstore.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Logstore.Infra.Repositorys
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly LogStoreContext _context;
        public PedidoRepository(LogStoreContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> BuscaPedidosPorCliente(string email)
        {
            IQueryable<Pedido> query = _context.Pedidos
            .Include(c=>c.cliente)
            .Where(c=>c.cliente.Email== email);
            return await query.ToListAsync();
        }
    }
}