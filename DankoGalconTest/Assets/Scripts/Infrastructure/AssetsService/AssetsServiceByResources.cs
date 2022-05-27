using System.Collections.Generic;
using System.Threading.Tasks;
using Galcon.Core;
using UnityEngine;

namespace Galcon.Infrastructure.AssetsService
{
    internal sealed class AssetsServiceByResources : IAssetsService
    {
        public Task<T> LoadAssetAsync<T>(string assetPath) where T : Object
        {
            var tcs = new TaskCompletionSource<T>();

            ResourceRequest req = Resources.LoadAsync<T>(assetPath);
            req.completed += op =>
            {
                Object asset = ((ResourceRequest) op).asset;
                tcs.SetResult((T) asset);
            };

            return tcs.Task;
        }

        public Task<IList<T>> LoadAllAssetsAsync<T>(string assetsPath) where T : Object
        {
            T[] assets = Resources.LoadAll<T>(assetsPath);

            return Task.FromResult<IList<T>>(assets);
        }
    }
}
