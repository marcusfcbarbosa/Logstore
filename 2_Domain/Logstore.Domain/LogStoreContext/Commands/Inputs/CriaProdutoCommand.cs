using FluentValidator;
using FluentValidator.Validation;
using Logstore.Shared.Commands;

namespace Logstore.Domain.LogStoreContext.Commands.Inputs
{
    public class CriaProdutoCommand : Notifiable, ICommand
    {

        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public void Validate()
        {
            AddNotifications(new ValidationContract()
                 .Requires()
                 .IsNotNull(Descricao, "Descricao", "Descricao é obrigatório")
                 .IsNotNull(Valor, "Valor", "Valor é obrigatório")
             );
        }
    }
}