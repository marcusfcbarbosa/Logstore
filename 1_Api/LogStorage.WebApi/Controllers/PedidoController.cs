using System;
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
    public class PedidoController
    {
        private readonly PedidoHandler _pedidoHandler;
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoController(PedidoHandler pedidoHandler, IPedidoRepository pedidoRepository)
        {
            _pedidoHandler = pedidoHandler;
            _pedidoRepository = pedidoRepository;
        }

        [HttpPost("")]
        public ICommandResult Post([FromBody] CriaPedidoCommand command)
        {
            try
            {
                return _pedidoHandler.Handle(command);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message, StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{email}")]
        public ICommandResult Get(string email)
        {
            try
            {
                var pedidos = _pedidoRepository.BuscaPedidosPorCliente(email);
                return new CommandResult(true, "", pedidos);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message, StatusCodes.Status500InternalServerError);
            }
        }



    }
}