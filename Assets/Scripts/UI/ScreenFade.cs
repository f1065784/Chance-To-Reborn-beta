using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Game.RoomSystem.UI
{
    public class ScreenFade : MonoBehaviour
    {
        [SerializeField] private Image fadeImage;
        [SerializeField] private float fadeDuration = 1f;
        [SerializeField] private GameObject fadeObject;

        private Tween _currentFadeTween;
        private bool _isFading; 

        void Start()
        {
            ResetFadeState();
        }

        private void ResetFadeState()
        {
            _currentFadeTween?.Kill();
            _currentFadeTween = null;
            _isFading = false;
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
            fadeObject.SetActive(false);
        }

        public void FadeOutAndIn(System.Action onFadeComplete)
        {
            if (_isFading) return; 

            _isFading = true;
            fadeObject.SetActive(true);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);

            _currentFadeTween = fadeImage.DOFade(1f, fadeDuration / 2f)
                .OnComplete(() =>
                {
                    onFadeComplete?.Invoke();

                    _currentFadeTween = fadeImage.DOFade(0f, fadeDuration / 2f)
                        .OnComplete(() =>
                        {
                            ResetFadeState(); 
                        })
                        .OnKill(() =>
                        {
                            ResetFadeState(); 
                        });
                })
                .OnKill(() =>
                {
                    ResetFadeState(); 
                });
        }

        private void OnDisable()
        {
            ResetFadeState();
        }
    }
}
