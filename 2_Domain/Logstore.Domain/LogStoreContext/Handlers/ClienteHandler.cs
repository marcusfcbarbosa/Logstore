using FluentValidator;
using Logstore.Domain.LogStoreContext.Commands.Inputs;
using Logstore.Domain.LogStoreContext.Repositories.Interfaces;
using Logstore.Shared.Commands;

namespace Logstore.Domain.LogStoreContext.Handlers
{
    public class ClienteHandler : Notifiable,
    ICommandHandler<CriaClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public ICommandResult Handle(CriaClienteCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}