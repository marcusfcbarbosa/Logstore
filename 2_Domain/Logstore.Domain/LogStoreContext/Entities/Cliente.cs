using Logstore.Domain.LogStoreContext.ValueObjects;
using Logstore.Shared.Entities;

namespace Logstore.Domain.LogStoreContext.Entities
{
    public class Cliente : Entity
    {
        public Cliente(string nome, Email email, Endereco endereco)
        {
            this.Nome = nome;
            this.Email = email;
            this.endereco = endereco;

        }
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Endereco endereco { get; private set; }
    }
}