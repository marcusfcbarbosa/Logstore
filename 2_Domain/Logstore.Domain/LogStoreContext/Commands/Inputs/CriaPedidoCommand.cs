using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using FluentValidator.Validation;
using Logstore.Shared.Commands;

namespace Logstore.Domain.LogStoreContext.Commands.Inputs
{
    public class CriaPedidoCommand : Notifiable, ICommand
    {
        public String NomeCliente { get; set; }
        public String EmailCliente { get; set; }
        public List<CriaPedidoProdutoCommand> lista { get; set; }
        public void Validate()
        {
            AddNotifications(new ValidationContract()
                 .Requires()
                 .IsNotNull(NomeCliente, "NomeCliente", "NomeCliente é obrigatório")
                 .IsNotNull(EmailCliente, "EmailCliente", "EmailCliente é obrigatório")
                 .IsLowerThan(lista.Count(),0,"","Necessita informar quantidade do pedido")
             );
        }
    }

    

}