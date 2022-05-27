using JetBrains.Annotations;

namespace Galcon.Core
{
    public interface IGameStateRepository
    {
        void AddState<TState>([NotNull] TState state) where TState : IExitableState;
    }
}
