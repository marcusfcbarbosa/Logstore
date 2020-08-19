using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using Logstore.Domain.LogStoreContext.Commands.Inputs;
using Logstore.Domain.LogStoreContext.Commands.Outputs;
using Logstore.Domain.LogStoreContext.Entities;
using Logstore.Domain.LogStoreContext.Repositories.Interfaces;
using Logstore.Domain.LogStoreContext.ValueObjects;
using Logstore.Shared.Commands;

namespace Logstore.Domain.LogStoreContext.Handlers
{
    public class PedidoHandler : Notifiable,
    ICommandHandler<CriaPedidoCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;

        private readonly IProdutoPedidoRepository _produtopedidoRepository;

        public PedidoHandler(IPedidoRepository pedidoRepository,
        IClienteRepository clienteRepository, IProdutoRepository produtoRepository,
        IProdutoPedidoRepository produtopedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _produtopedidoRepository = produtopedidoRepository;

        }
        public ICommandResult Handle(CriaPedidoCommand command)
        {
            List<ProdutoPedido> produtoPedidos = new List<ProdutoPedido>();
            Dictionary<Produto, int> envio = new Dictionary<Produto, int>();
            command.Validate();
            if (!command.Valid)
            {
                return new CommandResult(false, "Campos enviados com erro", command.Notifications);
            }
            var cliente = _clienteRepository.RetornaClientePorEmail(command.EmailCliente);
            if (cliente == null)
            {
                var email = new Email(command.EmailCliente);
                cliente = new Cliente(command.NomeCliente, email);
                _clienteRepository.Create(cliente);
                _clienteRepository.SaveChanges();
                cliente = _clienteRepository.RetornaClientePorEmail(command.EmailCliente);
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
            
            foreach (var kvp in envio)
            {
                ProdutoPedido produtoPedido = new ProdutoPedido((kvp.Key as Produto), kvp.Value, pedido);              
               _produtopedidoRepository.Create(produtoPedido);
               _produtopedidoRepository.SaveChanges();
            }

            return new CommandResult(true, "", new
            {
                Identificador = pedido.identifyer,
                Descricao = "Compra Realizada com sucesso!!"
            });
        }
    }
}