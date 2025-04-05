using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using Game.SelectionSystem.Object;
using DG.Tweening;

namespace Game.SelectionSystem.UI
{
    public class SelectionUI : MonoBehaviour
    {
        [SerializeField] private GameObject selectionWindow;
        [SerializeField] private TMP_Text questionText;
        [SerializeField] private Button option1Button;
        [SerializeField] private Button option2Button;
        [SerializeField] private Button option3Button;
        [SerializeField] private float animationDuration = 0.3f;
        [SerializeField] private AudioClip selectionSound;

        public event Action onSelectionClosed;
        private SelectionObject currentSelectionObject;
        private AudioClip previousMusic;

        public void ShowSelection(SelectionObject selectionObject)
        {
            currentSelectionObject = selectionObject;
            selectionWindow.transform.localScale = Vector3.zero;
            selectionWindow.SetActive(true);
            selectionWindow.transform.DOScale(1, animationDuration).SetEase(Ease.OutBack);

            questionText.text = selectionObject.Question;

            //previousMusic = SoundManager.Instance.GetCurrentMusic();
            //SoundManager.Instance.PlaySound(selectionSound);

            if (currentSelectionObject.hasOneOption)
            {
                option1Button.gameObject.SetActive(false);
                option2Button.gameObject.SetActive(false);
                option3Button.gameObject.SetActive(true);
                option3Button.GetComponentInChildren<TMP_Text>().text = selectionObject.Answer3;
                option3Button.onClick.RemoveAllListeners();
                option3Button.onClick.AddListener(() => HandleSelection(2));
            }
            else
            {
                option1Button.gameObject.SetActive(true);
                option2Button.gameObject.SetActive(true);
                option3Button.gameObject.SetActive(false);
                option1Button.GetComponentInChildren<TMP_Text>().text = selectionObject.Answer1;
                option2Button.GetComponentInChildren<TMP_Text>().text = selectionObject.Answer2;

                option1Button.onClick.RemoveAllListeners();
                option2Button.onClick.RemoveAllListeners();

                option1Button.onClick.AddListener(() => HandleSelection(0));
                option2Button.onClick.AddListener(() => HandleSelection(1));
            }
        }

        private void HandleSelection(int optionIndex)
        {
            if (currentSelectionObject != null)
            {
                if (optionIndex == 0)
                {
                    currentSelectionObject.OnAnswer1Selected?.Invoke();
                }
                else if (optionIndex == 1)
                {
                    currentSelectionObject.OnAnswer2Selected?.Invoke();
                }
                else
                {
                    currentSelectionObject.OnAnswer3Selected?.Invoke();
                }
            }
            CloseSelection();
        }

        private void CloseSelection()
        {
            //SoundManager.Instance.PlayMusic(previousMusic);
            selectionWindow.transform.DOScale(0, animationDuration).SetEase(Ease.InBack).OnComplete(() =>
            {
              selectionWindow.SetActive(false);
              onSelectionClosed?.Invoke();
            });
        }
    }
}
