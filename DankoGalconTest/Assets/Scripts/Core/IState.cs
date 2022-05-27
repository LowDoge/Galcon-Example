using System.Threading.Tasks;

namespace Galcon.Core
{
    public interface IExitableState
    {
        Task ExitAsync();
    }

    public interface IState : IExitableState
    {
        Task EnterAsync();
    }

    public interface IState<in TArg> : IExitableState
    {
        Task EnterAsync(TArg arg);
    }
}
