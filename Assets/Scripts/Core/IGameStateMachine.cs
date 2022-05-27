using System.Threading.Tasks;

namespace Galcon.Core
{
    public interface IGameStateMachine
    {
        IGameStateRepository States { get; }

        Task EnterAsync<TState>() where TState : IState;
        Task EnterAsync<TState, TArg>(TArg arg) where TState : IState<TArg>;
    }
}
