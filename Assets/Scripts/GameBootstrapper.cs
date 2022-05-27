using UnityEngine;
using Galcon.Core;
using Galcon.Core.Components;
using Galcon.Infrastructure.AssetsService;
using Galcon.Infrastructure.GameStateMachine;
using Galcon.Infrastructure.SceneService;

namespace Galcon
{
    [DisallowMultipleComponent]
    public sealed class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;
        [SerializeField] private string _mainSceneName;

        private Game _game;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            _game = new Game(new GameStateMachine(new GameStateRepository()), new AssetsServiceByResources(),
                new ScenesServiceBySceneManager(), _loadingCurtain, _mainSceneName);
        }

        private async void Start() => await _game.StartAsync();
    }
}
