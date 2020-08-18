using FluentValidator;
using Logstore.Domain.LogStoreContext.Commands.Inputs;
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

        public PedidoHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public ICommandResult Handle(CriaPedidoCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}