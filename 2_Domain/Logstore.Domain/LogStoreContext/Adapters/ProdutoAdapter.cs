using System.Collections.Generic;
using System.Linq;
using Logstore.Domain.LogStoreContext.Entities;
using Logstore.Domain.LogStoreContext.ViewModels;

namespace Logstore.Domain.LogStoreContext.Adapters
{
    public static class ProdutoAdapter
    {
        //|Ao invés de usar AutoMapper , trabalhando em cima de reflexion, prefiro usar assim.
        //Quando trafega alto volume de informação reflexion se torna lento
        public static ProdutoViewModel DomainToViewModel(Produto produto)
        {
            return new ProdutoViewModel
            {
                id = produto.Id,
                identifyer = produto.identifyer,
                Descricao = produto.Descricao,
                Valor = produto.Valor
            };
        }

        public static IEnumerable<ProdutoViewModel> DomainToViewModel(IEnumerable<Produto> produtos)
        {
            List<ProdutoViewModel> list = new List<ProdutoViewModel>();
            for (int i = 0; i < produtos.Count(); i++)
            {
                list.Add(
                    new ProdutoViewModel
                    {
                        id = produtos.ElementAt(i).Id,
                        identifyer = produtos.ElementAt(i).identifyer,
                        Descricao = produtos.ElementAt(i).Descricao,
                        Valor = produtos.ElementAt(i).Valor,
                    }
                );
            }
            return list;
        }


    }
}