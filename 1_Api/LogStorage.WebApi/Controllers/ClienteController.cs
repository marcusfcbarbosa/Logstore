using System;
using System.Threading.Tasks;
using Logstore.Domain.LogStoreContext.Commands.Inputs;
using Logstore.Domain.LogStoreContext.Commands.Outputs;
using Logstore.Domain.LogStoreContext.Handlers;
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
        public ClienteController(ClienteHandler clienteHandler)
        {
            _clienteHandler = clienteHandler;
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
    }
}