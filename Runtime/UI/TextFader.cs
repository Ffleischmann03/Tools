#define FOXTOOLS_DOTWEEN

#if FOXTOOLS_DOTWEEN

using System;
using UnityEngine;
using DG.Tweening;

namespace FoxTools.UI
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CanvasGroup))]
    public class TextFader : MonoBehaviour
    {
        [SerializeField, Min(0.01f)]
        private float timeToFadeIn = 0.5f;

        [SerializeField, Min(0f)]
        private float delayAfterFade = 0.5f;

        [SerializeField]
        private TextFader previousText;

        [SerializeField]
        private bool playOnStart = false;

        private CanvasGroup canvasGroup;
        private Tween fadeTween;
        private TextFader subscribedPreviousText;

        public event Action FadeComplete;

        private void Awake()
        {
            CacheCanvasGroup();

            if (previousText != null)
                SetHidden();
        }

        private void OnEnable()
        {
            subscribedPreviousText = previousText;

            if (subscribedPreviousText != null)
                subscribedPreviousText.FadeComplete += StartFade;
        }

        private void Start()
        {
            if (previousText == null && playOnStart)
                StartFade();
        }

        private void OnDisable()
        {
            if (subscribedPreviousText != null)
                subscribedPreviousText.FadeComplete -= StartFade;

            subscribedPreviousText = null;

            StopFade();
        }

        public void StartFade()
        {
            if (!isActiveAndEnabled)
                return;

            CacheCanvasGroup();
            StopFade();
            SetHidden();

            Sequence sequence = DOTween.Sequence();
            fadeTween = sequence;

            sequence.SetAutoKill(true);

            sequence.Append(
                DOTween.To(
                    () => canvasGroup.alpha,
                    value => canvasGroup.alpha = value,
                    1f,
                    Mathf.Max(0.01f, timeToFadeIn))
                .SetEase(Ease.InQuad)
            );

            sequence.AppendCallback(() =>
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            });

            sequence.AppendInterval(Mathf.Max(0f, delayAfterFade));

            sequence.OnComplete(() =>
            {
                FadeComplete?.Invoke();
            });

            sequence.OnKill(() =>
            {
                // A completion listener might have started a new fade.
                if (ReferenceEquals(fadeTween, sequence))
                    fadeTween = null;
            });
        }

        private void StopFade()
        {
            Tween tween = fadeTween;
            fadeTween = null;
            tween?.Kill();
        }

        private void CacheCanvasGroup()
        {
            if (canvasGroup == null)
                canvasGroup = GetComponent<CanvasGroup>();
        }

        private void SetHidden()
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}

#endif