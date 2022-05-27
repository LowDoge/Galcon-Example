using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Galcon.Core;
using UnityEngine;

namespace Galcon.Infrastructure.SceneService
{
    internal sealed class ScenesServiceBySceneManager : IScenesService
    {
        public Task LoadSceneAsync(string sceneName, LoadSceneMode mode)
        {
            var tcs = new TaskCompletionSource<bool>();

            AsyncOperation loadingOp = SceneManager.LoadSceneAsync(sceneName, mode);
            loadingOp.completed += _ => tcs.SetResult(true);

            return tcs.Task;
        }
    }
}
