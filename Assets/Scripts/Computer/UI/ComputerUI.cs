using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using Game.SelectionSystem.Object;
using DG.Tweening;
using Game.DialogeSystem.UI;

namespace Game.Computer
{

    public class ComputerUI : MonoBehaviour
    {
        [SerializeField] private GameObject selectionWindow;
        [SerializeField] private Button option1Button;
        [SerializeField] private Button option2Button;
        [SerializeField] private Button option3Button;
        [SerializeField] private float animationDuration = 0.7f;

        public event Action onSelectionClosed;
        private bool hasBeenOpened = false;

        public void ShowSelection()
        {
            if (hasBeenOpened) return;
            selectionWindow.transform.localScale = Vector3.zero;
            selectionWindow.SetActive(true);
            selectionWindow.transform.DOScale(1, animationDuration).SetEase(Ease.OutBack);
            option1Button.onClick.AddListener(() => HandleSelection(0));
            option2Button.onClick.AddListener(() => HandleSelection(1));
            option3Button.onClick.AddListener(() => HandleSelection(2));
            DialogeUI.IsOPen = true;
        }

        private void HandleSelection(int optionIndex)
        {
            if (hasBeenOpened) return;
            if (optionIndex == 0)
            {
                Balance.Instance.SubstructBalance(60000);
                int random = UnityEngine.Random.Range(0, 100);
                if (random <= 50)
                {
                  //  Balance.Instance.AddBalance(120000);
                    PlayerPrefs.SetInt("ChooseNewBuisnessPath", 1);
                    PlayerPrefs.SetInt("ChooseCrisisPath", 0);
                }
                else
                {
                    PlayerPrefs.SetInt("ChooseNewBuisnessPath", 0);
                    PlayerPrefs.SetInt("ChooseCrisisPath", 1);
                }
            }
            if (optionIndex == 1)
            {
                int random = UnityEngine.Random.Range(0, 100);
                if (random <= 50)
                {
                    //Balance.Instance.AddBalance(120000);
                    PlayerPrefs.SetInt("ChooseNewBuisnessPath", 1);
                    PlayerPrefs.SetInt("ChooseCrisisPath", 0);
                }
                else
                {
                    PlayerPrefs.SetInt("ChooseNewBuisnessPath", 0);
                    PlayerPrefs.SetInt("ChooseCrisisPath", 1);
                }
            }
            if (optionIndex == 2)
            {
                int random = UnityEngine.Random.Range(0, 100);
                if (random <= 99)
                {
                   // Balance.Instance.AddBalance(120000);
                    PlayerPrefs.SetInt("ChooseNewBuisnessPath", 1);
                    PlayerPrefs.SetInt("ChooseCrisisPath", 0);
                }
                else
                {
                    PlayerPrefs.SetInt("ChooseNewBuisnessPath", 0);
                    PlayerPrefs.SetInt("ChooseCrisisPath", 1);
                }
            }
            hasBeenOpened = true;
            Debug.Log("Option " + optionIndex + " selected");
            Debug.Log("Win: " + PlayerPrefs.GetInt("ChooseNewBuisnessPath"));
            DialogeUI.IsOPen = false;
            Invoke(nameof(CloseSelection), 0.5f);
        }

        private void CloseSelection()
        {
            selectionWindow.transform.DOScale(0, animationDuration).SetEase(Ease.InBack).OnComplete(() =>
            {
                selectionWindow.SetActive(false);
            });
        }
    }
}
