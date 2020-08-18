using Logstore.Domain.LogStoreContext.Entities;
using Logstore.Domain.LogStoreContext.Repositories.Interfaces;
using Logstore.Infra.Context;

namespace Logstore.Infra.Repositorys
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly LogStoreContext _context;
        public ClienteRepository(LogStoreContext context) : base(context)
        {
             _context = context;
        }
    }
}