using System.Collections.Generic;
using Logstore.Domain.LogStoreContext.ValueObjects.Enums;
using Logstore.Shared.Entities;

namespace Logstore.Domain.LogStoreContext.Entities
{
    public class Pedido : Entity
    {

        public Pedido(Cliente cliente, int quantidade, Status status)
        {
            this.cliente = cliente;
            this.Quantidade = quantidade;
            this.status = status;
        }

        public void PedidoRealizado()
        {
            this.status = Status.Realizado;
        }
        public int Quantidade { get; private set; }
        public bool FreteGratis { get; private set; } = false;
        public Status status { get; private set; }
        public List<Produto> Produtos { get; set; }

        public int ClienteId { get; private set; }
        public Cliente cliente { get; private set; }
    }
}