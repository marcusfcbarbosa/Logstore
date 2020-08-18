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
        
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
    }
}