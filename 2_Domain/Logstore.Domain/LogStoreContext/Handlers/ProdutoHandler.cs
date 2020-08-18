using FluentValidator;
using Logstore.Domain.LogStoreContext.Commands.Inputs;
using Logstore.Domain.LogStoreContext.Repositories.Interfaces;
using Logstore.Shared.Commands;

namespace Logstore.Domain.LogStoreContext.Handlers
{
    public class ProdutoHandler : Notifiable,
    ICommandHandler<CriaProdutoCommand>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public ICommandResult Handle(CriaProdutoCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}