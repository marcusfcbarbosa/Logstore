using System.Collections.Generic;
using Logstore.Domain.LogStoreContext.ValueObjects.Enums;
using Logstore.Shared.Entities;

namespace Logstore.Domain.LogStoreContext.Entities
{
    public class Pedido : Entity
    {

        private Pedido() { }
        public Pedido(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public void PedidoRealizado()
        {
            this.status = Status.Realizado;
        }
        public void AdicionaProdutosAoPedido(Produto produto, int quantidade)
        {
            var produtoPedido = new ProdutoPedido(produto, quantidade, this);
            this.ProdutoPedidos.Add(produtoPedido);
        }


        public void EhFreteGrtis()
        {
            this.FreteGratis = true;
        }

        public decimal ValorPedido { get; private set; }

        public void AdicionValorPedido(decimal valorPedido)
        {
                this.ValorPedido = valorPedido;
        }   

        public bool FreteGratis { get; private set; } = false;
        public Status status { get; private set; }
        public List<ProdutoPedido> ProdutoPedidos { get; set; }

        public int ClienteId { get; private set; }
        public Cliente cliente { get; private set; }
    }
}