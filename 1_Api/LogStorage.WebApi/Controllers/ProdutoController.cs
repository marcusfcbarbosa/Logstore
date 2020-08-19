using System;
using Logstore.Domain.LogStoreContext.Adapters;
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
    public class ProdutoController
    {
        private readonly ProdutoHandler _produtoHandler;
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoController(ProdutoHandler produtoHandler
        , IProdutoRepository produtoRepository)
        {
            _produtoHandler = produtoHandler;
            _produtoRepository = produtoRepository;
        }

        [HttpPost("")]
        public ICommandResult Post([FromBody] CriaProdutoCommand command)
        {
            try
            {
                return _produtoHandler.Handle(command);
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
                var produtos = ProdutoAdapter.DomainToViewModel(_produtoRepository.RetornaTodosProdutos());
                return new CommandResult(true, "", produtos);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message, StatusCodes.Status500InternalServerError);
            }
        }



    }
}