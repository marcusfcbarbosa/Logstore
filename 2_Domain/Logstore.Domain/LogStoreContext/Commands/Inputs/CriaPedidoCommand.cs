using System;
using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using Logstore.Shared.Commands;

namespace Logstore.Domain.LogStoreContext.Commands.Inputs
{
    public class CriaPedidoCommand : Notifiable, ICommand
    {
        public String EmailCliente { get; set; }
        public List<CriaPedidoProdutoCommand> lista { get; set; }

        public void Validate()
        {
            AddNotifications(new ValidationContract()
                 .Requires()
                 .IsNotNull(EmailCliente, "EmailCliente", "EmailCliente é obrigatório")
                 .IsNotNull(Valor, "Valor", "Valor é obrigatório")
             );
        }
    }

    

}