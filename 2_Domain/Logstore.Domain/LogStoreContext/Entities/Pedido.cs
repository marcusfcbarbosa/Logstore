using Logstore.Domain.LogStoreContext.ValueObjects.Enums;
using Logstore.Shared.Entities;

namespace Logstore.Domain.LogStoreContext.Entities
{
    public class Pedido : Entity
    {

        public Pedido(Cliente cliente, Produto produto, int quantidade, Status status)
        {
            this.cliente = cliente;
            this.produto = produto;
            this.Quantidade = quantidade;
            this.status = status;
        }

        public void PedidoRealizado()
        {
            this.status = Status.Realizado;
        }
        public Cliente cliente { get; private set; }
        public Produto produto { get; private set; }
        public int Quantidade { get; private set; }
        public Status status { get; private set; }

    }
}