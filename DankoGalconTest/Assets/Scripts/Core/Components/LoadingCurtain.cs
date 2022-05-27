using System.Collections;
using UnityEngine;
using Galcon.Core.GameStates;

namespace Galcon.Core.Components
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        [SerializeField] private CanvasGroup _curtain;
        [SerializeField] private float _fadeAlphaSpeed;

        private void Awake()
        {
            _curtain ??= GetComponent<CanvasGroup>();

            DontDestroyOnLoad(gameObject);
        }

        public void Show()
        {
            _curtain.alpha = 1;
            gameObject.SetActive(true);
        }

        public void Hide() => StartCoroutine(FadeInRoutine());

        private IEnumerator FadeInRoutine()
        {
            while (_curtain.alpha > 0)
            {
                yield return null;
                _curtain.alpha -= _fadeAlphaSpeed * Time.deltaTime;
            }

            gameObject.SetActive(false);
        }
    }
}
