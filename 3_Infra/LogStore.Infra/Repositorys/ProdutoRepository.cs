using System.Linq;
using System.Threading.Tasks;
using Logstore.Domain.LogStoreContext.Entities;
using Logstore.Domain.LogStoreContext.Repositories.Interfaces;
using Logstore.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Logstore.Infra.Repositorys
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly LogStoreContext _context;
        public ProdutoRepository(LogStoreContext context) : base(context)
        {
            _context = context;
        }
        public Produto RetornaProdutoPelaDescricao(string descricao)
        {
            IQueryable<Produto> query = _context.Produtos
            .Where(p => p.Descricao == descricao);
            return  query.FirstOrDefault();
        }
    }
}