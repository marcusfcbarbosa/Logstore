using FluentValidator;
using Logstore.Domain.LogStoreContext.Commands.Inputs;
using Logstore.Domain.LogStoreContext.Commands.Outputs;
using Logstore.Domain.LogStoreContext.Entities;
using Logstore.Domain.LogStoreContext.Repositories.Interfaces;
using Logstore.Domain.LogStoreContext.ValueObjects;
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
            command.Validate();
            if (!command.Valid)
            {
                return new CommandResult(false, "Campos enviados com erro", command.Notifications);
            }
            var email = new Email(command.Email);
            var cliente = new Cliente(command.Nome, email);
            
            _clienteRepository.Create(cliente);
            _clienteRepository.SaveChanges();
            return new CommandResult(true, "Bem vindo", new
            {
                Id = cliente.Id,
                Email = cliente.Email
            });
        }
    }
}