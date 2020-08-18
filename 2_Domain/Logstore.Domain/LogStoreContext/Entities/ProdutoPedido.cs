using Logstore.Shared.Entities;

namespace Logstore.Domain.LogStoreContext.Entities
{
    public class ProdutoPedido : Entity
    {
        private ProdutoPedido() { }
        public ProdutoPedido(Produto produto,int quantidadeProduto, Pedido pedido)
        {
            this.produto = produto;
            this.pedido = pedido;
            this.QuantidadeProduto = quantidadeProduto;
        }

        public int QuantidadeProduto { get; private set; }

        public int ProdutoId { get; private set; }
        public Produto produto { get; private set; }

        public Pedido pedido { get; private set; }
        public int PedidoId { get; private set; }

    }
}