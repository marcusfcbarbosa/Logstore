using System.Threading.Tasks;

namespace Logstore.Shared.Commands
{
    public interface ICommandHandlerAsync<T> where T : ICommand
    {
          Task<ICommandResult> Handle(T command);
    }
}