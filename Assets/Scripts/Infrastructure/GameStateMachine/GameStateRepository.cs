using System;
using System.Collections.Generic;
using Galcon.Core;

namespace Galcon.Infrastructure.GameStateMachine
{
    internal sealed class GameStateRepository : IExtendedGameStateRepository
    {
        private readonly IDictionary<Type, IExitableState> _statesMap = new Dictionary<Type, IExitableState>();

        public void AddState<TState>(TState state) where TState : IExitableState => _statesMap[typeof(TState)] = state;

        public TState GetState<TState>() where TState : IExitableState => (TState) _statesMap[typeof(TState)];
    }
}
