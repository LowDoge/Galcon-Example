using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Galcon.Core.GameStates
{
    public sealed class GameLoadingState : IState<string>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IScenesService _scenesService;
        private readonly IAssetsService _assetsService;
        private readonly ILoadingCurtain _loadingCurtain;

        public GameLoadingState([NotNull] IGameStateMachine stateMachine, [NotNull] IScenesService scenesService,
            [NotNull] IAssetsService assetsService, [NotNull] ILoadingCurtain loadingCurtain)
        {
            _stateMachine = stateMachine;
            _scenesService = scenesService;
            _assetsService = assetsService;
            _loadingCurtain = loadingCurtain;
        }

        public async Task EnterAsync(string mainSceneName)
        {
            _loadingCurtain.Show();

            await _scenesService.LoadSceneAsync(mainSceneName);
            await _stateMachine.EnterAsync<GameMainState>();
        }

        public Task ExitAsync()
        {
            _loadingCurtain.Hide();

            return Task.CompletedTask;
        }
    }
}
