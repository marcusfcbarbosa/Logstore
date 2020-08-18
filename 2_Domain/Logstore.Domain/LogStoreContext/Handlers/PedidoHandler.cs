using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using Logstore.Domain.LogStoreContext.Commands.Inputs;
using Logstore.Domain.LogStoreContext.Commands.Outputs;
using Logstore.Domain.LogStoreContext.Entities;
using Logstore.Domain.LogStoreContext.Repositories.Interfaces;
using Logstore.Shared.Commands;

namespace Logstore.Domain.LogStoreContext.Handlers
{
    public class PedidoHandler : Notifiable,
    ICommandHandler<CriaPedidoCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoHandler(IPedidoRepository pedidoRepository,
        IClienteRepository clienteRepository, IProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
        }
        public ICommandResult Handle(CriaPedidoCommand command)
        {
            List<ProdutoPedido> produtoPedidos = new List<ProdutoPedido>();
            Dictionary<Produto, int> envio = new Dictionary<Produto, int>();
            command.Validate();
            if (!command.Valid)
            {
                return new CommandResult(false, "Campos enviados com erro", Notifications);
            }
            var cliente = _clienteRepository.RetornaClientePorEmail(command.EmailCliente);
            if (cliente == null)
            {
                return new CommandResult(false, "Cliente nao encontrado", null);
            }

            for (int i = 0; i < command.lista.Count(); i++)
            {
                var produto = _produtoRepository.RetornaProdutoPelaDescricao(command.lista.ElementAt(i).Descricao);
                if (produto != null)
                {
                    envio.Add(produto, command.lista.ElementAt(i).Quantidade);
                }
            }

            var pedido = new Pedido(cliente);
            decimal valorPedido = 0;
            foreach (var kvp in envio)
            {
                pedido.AdicionaProdutosAoPedido(kvp.Key, kvp.Value);
                valorPedido += (kvp.Key as Produto).Valor * kvp.Value;
            }

            var pedidosAnteriores = _pedidoRepository.BuscaPedidosPorCliente(command.EmailCliente);
            if (!pedidosAnteriores.Any())
            {
                pedido.EhFreteGrtis();
            }
            else
            {
                valorPedido += 10;
            }
            pedido.AdicionValorPedido(valorPedido);
            _pedidoRepository.Create(pedido);
            _pedidoRepository.SaveChanges();

            return new CommandResult(true, "", new
            {
                Identificador = pedido.identifyer,
                Descricao = "Compra Realizada com sucesso!!"
            });
        }
    }
}