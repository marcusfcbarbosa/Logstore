using System.Collections.Generic;
using System.Linq;
using Logstore.Domain.LogStoreContext.Entities;
using Logstore.Domain.LogStoreContext.ViewModels;

namespace Logstore.Domain.LogStoreContext.Adapters
{
    public static class ClienteAdapter
    {
        public static ClienteViewModel DomainToViewModel(Cliente cliente)
        {
            return new ClienteViewModel
            {
                id = cliente.Id,
                identifyer = cliente.identifyer,
                Email = cliente.Email,
                Nome = cliente.Nome
            };
        }

         public static IEnumerable<ClienteViewModel> DomainToViewModel(IEnumerable<Cliente> clientes)
        {
            List<ClienteViewModel> list = new List<ClienteViewModel>();
            for (int i = 0; i < clientes.Count(); i++)
            {
                list.Add(
                    new ClienteViewModel
                    {
                        id = clientes.ElementAt(i).Id,
                        identifyer = clientes.ElementAt(i).identifyer,
                        Email = clientes.ElementAt(i).Email,
                        Nome = clientes.ElementAt(i).Nome                     
                    }
                );
            }
            return list;
        }
    }
}