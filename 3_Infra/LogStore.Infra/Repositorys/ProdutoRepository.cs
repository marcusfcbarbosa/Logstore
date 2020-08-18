using Logstore.Domain.LogStoreContext.Entities;
using Logstore.Domain.LogStoreContext.Repositories.Interfaces;
using Logstore.Infra.Context;

namespace Logstore.Infra.Repositorys
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly LogStoreContext _context;
        public ProdutoRepository(LogStoreContext context) : base(context)
        {
            _context = context;
        }
    }
}