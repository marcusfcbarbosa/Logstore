using System.Threading.Tasks;
using Logstore.Domain.LogStoreContext.Entities;

namespace Logstore.Domain.LogStoreContext.Repositories.Interfaces
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
            Task<Produto> RetornaProdutoPelaDescricao(string descricao);
    }
}