using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DialogueHintUI : MonoBehaviour
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

    public void ShowHint(string npcName)
    {
        if (isHintVisible) HideHint();

        hintText.text = $"Íאזל³עü 'Å' שמב גחא÷למה³ÿעט ח {npcName}";
        hintPanel.anchoredPosition = originalPosition - new Vector2(0,20);
        hintCanvasGroup.DOFade(1, 0.5f);
        isHintVisible = true;
        hintPanel.DOAnchorPos(originalPosition, 0.5f).SetEase(Ease.OutBack);
    }

    public void HideHint()
    {
        isHintVisible = false;
        hintCanvasGroup.DOFade(0, 0.3f);
        hintPanel.DOAnchorPos(originalPosition -  new Vector2(0,20), 0.3f).SetEase(Ease.InBack);
    }   
}
