using Galcon.Core;

namespace Galcon.Infrastructure.GameStateMachine
{
    internal interface IExtendedGameStateRepository : IGameStateRepository
    {
        TState GetState<TState>() where TState : IExitableState;
    }
}
