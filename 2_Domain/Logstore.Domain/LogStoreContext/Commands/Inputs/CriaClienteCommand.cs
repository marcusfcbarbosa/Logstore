using System;
using FluentValidator;
using FluentValidator.Validation;
using Logstore.Shared.Commands;

namespace Logstore.Domain.LogStoreContext.Commands.Inputs
{
    public class CriaClienteCommand : Notifiable, ICommand
    {
        public String Nome { get;  set; }
        public String Email { get;  set; }

        public String Rua { get;  set; }
        public String Numero { get;  set; }
        public String Cidade { get;  set; }
        public String Estado { get;  set; }
        public String Pais { get;  set; }
        public String Cep { get; private set; }

        public void Validate()
        {
            AddNotifications(new ValidationContract()
                 .Requires()
                 .IsNotNull(Nome, "Nome", "Nome é obrigatório")
                 .IsNotNull(Email, "Email", "Email é obrigatório")
             );
        }
    }
}