using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

namespace Galcon.Core
{
    public interface ISceneService
    {
        Task LoadSceneAsync([NotNull] string sceneName, LoadSceneMode mode = LoadSceneMode.Single);
    }
}
