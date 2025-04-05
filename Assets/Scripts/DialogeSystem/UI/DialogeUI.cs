using System.Collections;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Game.DialogeSystem.Data;
using Game.DialogeSystem.Responses;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Game.SelectionSystem.UI;
using System;

namespace Game.DialogeSystem.UI{
    public class DialogeUI : MonoBehaviour
    {
        [SerializeField] private GameObject DialogeBox;
        [SerializeField] private TMP_Text textLabel;
        [SerializeField] private SelectionUI selectionUI;
        [SerializeField] private float animationDuration = 0.3f;

        private TypeWriterEffect typeWriterEffect;
        private ResponceHandler responceHandler;
        public static bool IsOPen{get; set ;}
        public event Action OnDialogueClosed;

        float spaceCooldown = 0f;
        const float spaceCooldownTime = 0.3f;


        void Start()
        {
            typeWriterEffect = GetComponent<TypeWriterEffect>();
            responceHandler = GetComponent<ResponceHandler>();
            DialogeBox.SetActive(false);
            selectionUI.onSelectionClosed += CloseDialogueBoxFinal;
        }

        public void ShowDialogue(DialogeObject dialogueObject){
            IsOPen = true;
            DialogeBox.transform.localScale = Vector3.zero;
            DialogeBox.SetActive(true);
            StartCoroutine(StepThroughDialogue(dialogueObject));
            DialogeBox.transform.DOScale(1, animationDuration).SetEase(Ease.OutBack);
        }

        public void AddResponceEvents(ResponceEvent[] responceEvents)
        {
            responceHandler.AddResponceEvents(responceEvents);
        }

        private IEnumerator StepThroughDialogue(DialogeObject dialogueObject){
            foreach(var dialogue in dialogueObject.Dialogue){
                yield return RunTypingEffect(dialogue);
                textLabel.text = dialogue;
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            }

            if (dialogueObject.HasResponses)
            {
                responceHandler.ShowResponses(dialogueObject.Responses);
                yield break;
            }
            if (dialogueObject.HasSelection)
            {
                CloseDialogeBoxWithoutChangingState();
                selectionUI.ShowSelection(dialogueObject.Selection);
            }
            else
            {
                CloseDialogeBox();
            }
            OnDialogueClosed?.Invoke();
        }

        private IEnumerator RunTypingEffect(string dialogue)
        {
            typeWriterEffect.Run(dialogue, textLabel);
            
            while(typeWriterEffect.IsRunning)
            {
                spaceCooldown -= Time.deltaTime;
                
                if(Input.GetKeyDown(KeyCode.Space) && spaceCooldown <= 0f)
                {
                    typeWriterEffect.Stop();
                    spaceCooldown = spaceCooldownTime;
                }   
                
                yield return null;
            }
        }

        public void CloseDialogeBox(){
            DialogeBox.transform.DOScale(0, animationDuration).SetEase(Ease.InBack).OnComplete(() =>
            {
                IsOPen = false;
                DialogeBox.SetActive(false);
            });
        }

        public void CloseDialogeBoxWithoutChangingState()
        {
            DialogeBox.transform.DOScale(0, animationDuration).SetEase(Ease.InBack).OnComplete(() =>
            {
                DialogeBox.SetActive(false);
            });
        }
        private void CloseDialogueBoxFinal()
        {
            IsOPen = false;
        }
    }
}
