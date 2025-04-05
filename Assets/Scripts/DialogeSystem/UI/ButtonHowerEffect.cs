using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

namespace Game.UIEffects
{
    public class ButtonHowerEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Vector3 originalScale;
        [SerializeField] private bool changeColor = false;
        [SerializeField] private BGChanger bgChanger;
        private bool canChangeColor = true;
        private float colorChangeCooldown = 1.5f;

        private void Awake()
        {
            originalScale = transform.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DOScale(originalScale * 1.1f, 0.2f).SetEase(Ease.OutQuad);
            
            if (changeColor && canChangeColor && bgChanger != null)
            {
                bgChanger.OnRoomChanged();
                StartCoroutine(ColorChangeCooldown());
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(originalScale, 0.2f).SetEase(Ease.OutQuad);
        }

        private IEnumerator ColorChangeCooldown()
        {
            canChangeColor = false;
            yield return new WaitForSeconds(colorChangeCooldown);
            canChangeColor = true;
        }
    }
}