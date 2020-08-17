using Logstore.Domain.LogStoreContext.ValueObjects;
using Logstore.Shared.Entities;

namespace Logstore.Domain.LogStoreContext.Entities
{
    public class Cliente : Entity
    {
        public Cliente(string nome, Email email)
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; private set; }
         public Email Email { get; private set; }
    }
}