using System;
using System.Threading.Tasks;
using Logstore.Domain.LogStoreContext.Commands.Inputs;
using Logstore.Domain.LogStoreContext.Commands.Outputs;
using Logstore.Domain.LogStoreContext.Handlers;
using Logstore.Domain.LogStoreContext.Repositories.Interfaces;
using Logstore.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogStorage.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController
    {
        private readonly ClienteHandler _clienteHandler;
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(ClienteHandler clienteHandler,IClienteRepository clienteRepository)
        {
            _clienteHandler = clienteHandler;
            _clienteRepository = clienteRepository;
        }

        [HttpPost("")]
        public ICommandResult Post([FromBody] CriaClienteCommand command)
        {
            try
            {
                return _clienteHandler.Handle(command);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("")]
        public ICommandResult Get()
        {
            try
            {
                var clientes = _clienteRepository.RetornaTodosClientes();
                return new CommandResult(true, "", clientes);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}