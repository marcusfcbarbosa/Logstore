using System.Linq;
using System.Threading.Tasks;
using Logstore.Domain.LogStoreContext.Entities;
using Logstore.Domain.LogStoreContext.Repositories.Interfaces;
using Logstore.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Logstore.Infra.Repositorys
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly LogStoreContext _context;
        public ClienteRepository(LogStoreContext context) : base(context)
        {
            _context = context;
        }

        public Cliente RetornaClientePorEmail(string email)
        {
            IQueryable<Cliente> query = _context.Clientes
            .Where(p => p.Email == email);
            return  query.FirstOrDefault();
        }
    }
}