using System.Collections.Generic;
using Logstore.Domain.LogStoreContext.ValueObjects;
using Logstore.Shared.Entities;

namespace Logstore.Domain.LogStoreContext.Entities
{
    public class Cliente : Entity
    {

        private Cliente(){}
        public Cliente(string nome, Email email)
        {
            this.Nome = nome;
            this.Email = email.Address;
        }
        public void AdicionaPedido(Pedido pedido)
        {
            this.Pedidos.Add(pedido);
        }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Endereco endereco { get; private set; }
        public List<Pedido> Pedidos { get; set; }
    }
}