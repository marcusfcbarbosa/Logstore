using FluentValidator;
using Logstore.Domain.LogStoreContext.Commands.Inputs;
using Logstore.Domain.LogStoreContext.Commands.Outputs;
using Logstore.Domain.LogStoreContext.Entities;
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
            command.Validate();
            if (!command.Valid)
            {
                return new CommandResult(false, "Campos enviados com erro", command.Notifications);
            }

            var produto = new Produto(command.Descricao, command.Valor);
            _produtoRepository.Create(produto);
            _produtoRepository.SaveChanges();
            return new CommandResult(true, "", new
            {
                Id = produto.Id,
                Descricao = produto.Descricao
            });
        }
    }
}