using Logstore.Domain.LogStoreContext.Commands.Inputs;
using Logstore.Domain.LogStoreContext.Handlers;
using Logstore.Domain.LogStoreContext.Repositories.Interfaces;
using Logstore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace LogStorage.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController
    {
        private readonly ProdutoHandler _produtoHandler;
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoController(ProdutoHandler produtoHandler
        ,IProdutoRepository produtoRepository)
        {
            _produtoHandler = produtoHandler;
            _produtoRepository = produtoRepository;
        }

        [HttpPost("")]
        public ICommandResult Post([FromBody] CriaProdutoCommand command)
        {
            return _produtoHandler.Handle(command);
        }
    }
}