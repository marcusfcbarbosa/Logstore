using System.Collections.Generic;
using Logstore.Shared.Entities;

namespace Logstore.Domain.LogStoreContext.Entities
{
    public class Produto : Entity
    {
        private Produto(){}
        public Produto(string descricao, decimal valor)
        {
            this.Descricao = descricao;
            this.Valor = valor;
        }
        public void VinculaPedido(Pedido pedido){
                this.pedido = pedido;
        }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }

        public int PedidoId { get; private set; }
        public Pedido pedido { get; private set; }
    }
}