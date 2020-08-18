using Logstore.Domain.LogStoreContext.Commands.Inputs;
using Logstore.Domain.LogStoreContext.Handlers;
using Logstore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace LogStorage.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController
    {
        private readonly PedidoHandler _pedidoHandler;
        public PedidoController(PedidoHandler pedidoHandler)
        {
            _pedidoHandler = pedidoHandler;
        }

        [HttpPost("")]
        public ICommandResult Post([FromBody] CriaPedidoCommand command)
        {
            return _pedidoHandler.Handle(command);
        }
    }
}