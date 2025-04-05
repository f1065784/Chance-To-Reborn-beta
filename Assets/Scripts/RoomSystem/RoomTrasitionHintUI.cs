using DG.Tweening;
using TMPro;
using UnityEngine;

public class RoomTrasitionHintUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup hintCanvasGroup;
    [SerializeField] private TMP_Text hintText;
    [SerializeField] private RectTransform hintPanel;

    private Vector2 originalPosition;
    private bool isHintVisible = false;

    private void Start()
    {
        originalPosition = hintPanel.anchoredPosition;
        hintCanvasGroup.alpha = 0;
    }

    public void ShowHint()
    {
        if (isHintVisible) HideHint();

        hintText.text = "Натисніть 'Q' для входу в наступну кімнату";

        hintCanvasGroup.DOKill(true);
        hintPanel.DOKill(true);

        hintPanel.anchoredPosition = originalPosition - new Vector2(0, 20);
        hintCanvasGroup.DOFade(1, 0.5f);
        hintPanel.DOAnchorPos(originalPosition, 0.5f).SetEase(Ease.OutBack);
        isHintVisible = true;
    }

    public void HideHint()
    {
        if (!isHintVisible) return;

        hintCanvasGroup.DOKill(true);
        hintPanel.DOKill(true);

        hintCanvasGroup.DOFade(0, 0.3f).OnComplete(() => isHintVisible = false);
        hintPanel.DOAnchorPos(originalPosition - new Vector2(0, 20), 0.3f).SetEase(Ease.InBack);
    }

    public void HideHintAfterTransition()
    {
        if (isHintVisible)
        {
            HideHint();
        }
    }
}
