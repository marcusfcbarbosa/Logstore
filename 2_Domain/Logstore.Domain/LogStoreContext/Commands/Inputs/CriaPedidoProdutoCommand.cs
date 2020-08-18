
using FluentValidator;
using FluentValidator.Validation;
using Logstore.Shared.Commands;

namespace Logstore.Domain.LogStoreContext.Commands.Inputs
{
    public class CriaPedidoProdutoCommand : Notifiable, ICommand
    {
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        public void Validate()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNull(Descricao, "Descricao", "Descricao é obrigatório")
                .IsNotNull(Quantidade, "Quantidade", "Quantidade é obrigatório")
                .IsLowerThan(Quantidade, 1, "Quantidade deve ser no minimo 1", "Quantidade deve ser no minimo 1")
                .IsGreaterThan(Quantidade, 10, "Quantidade deve ser no maximo 10", "Quantidade deve ser no maximo 10")
            );
        }
    }
}