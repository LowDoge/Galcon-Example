using System.Threading.Tasks;
using Galcon.Core.GameStates;
using JetBrains.Annotations;

namespace Galcon.Core
{
    public sealed class Game
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IAssetsService _assetsService;
        private readonly IScenesService _scenesService;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly string _mainSceneName;

        public Game([NotNull] IGameStateMachine stateMachine, [NotNull] IAssetsService assetsService,
            [NotNull] IScenesService scenesService, [NotNull] ILoadingCurtain loadingCurtain,
            [NotNull] string mainSceneName)
        {
            _stateMachine = stateMachine;
            _assetsService = assetsService;
            _scenesService = scenesService;
            _loadingCurtain = loadingCurtain;
            _mainSceneName = mainSceneName;

            RegisterGameStates();
        }

        public Task StartAsync() => _stateMachine.EnterAsync<GameLoadingState, string>(_mainSceneName);

        private void RegisterGameStates()
        {
            IGameStateRepository stateRepository = _stateMachine.States;

            stateRepository.AddState(
                new GameLoadingState(_stateMachine, _scenesService, _assetsService, _loadingCurtain));
            stateRepository.AddState(new GameMainState());
        }
    }
}
