using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Galcon.Core
{
    public interface IAssetsService
    {
        Task<T> LoadAssetAsync<T>(string assetPath) where T : Object;
        Task<IList<T>> LoadAllAssetsAsync<T>(string assetsPath) where T : Object;
    }
}
