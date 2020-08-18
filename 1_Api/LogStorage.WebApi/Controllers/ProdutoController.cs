using Logstore.Domain.LogStoreContext.Commands.Inputs;
using Logstore.Domain.LogStoreContext.Handlers;
using Logstore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace LogStorage.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController
    {
        private readonly ProdutoHandler _produtoHandler;
        public ProdutoController(ProdutoHandler produtoHandler)
        {
            _produtoHandler = produtoHandler;
        }

        [HttpPost("")]
        public ICommandResult Post([FromBody] CriaProdutoCommand command)
        {
            return _produtoHandler.Handle(command);
        }
    }
}