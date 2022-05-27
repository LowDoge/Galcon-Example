using System.Threading.Tasks;

namespace Galcon.Core.GameStates
{
    public sealed class GameMainState : IState
    {
        public Task ExitAsync() => Task.CompletedTask;

        public Task EnterAsync() => Task.CompletedTask;
    }
}
