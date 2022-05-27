using System.Threading.Tasks;
using Galcon.Core;

namespace Galcon.Infrastructure.GameStateMachine
{
    internal sealed class GameStateMachine : IGameStateMachine
    {
        public IGameStateRepository States => _stateRepository;

        private readonly IExtendedGameStateRepository _stateRepository;
        private IExitableState _currentState;

        public GameStateMachine(IExtendedGameStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task EnterAsync<TState>() where TState : IState
        {
            TState state = await ChangeStateAsync<TState>();
            await state.EnterAsync();
        }

        public async Task EnterAsync<TState, TArg>(TArg arg) where TState : IState<TArg>
        {
            TState state = await ChangeStateAsync<TState>();
            await state.EnterAsync(arg);
        }

        private async Task<TState> ChangeStateAsync<TState>() where TState : IExitableState
        {
            await ExitCurrentStateAsync();

            var nextState = _stateRepository.GetState<TState>();
            _currentState = nextState;

            return nextState;
        }

        private Task ExitCurrentStateAsync() => _currentState?.ExitAsync() ?? Task.CompletedTask;
    }
}
