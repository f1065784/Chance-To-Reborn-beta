using UnityEngine;
using Game.DialogeSystem.Data;
using System;

namespace Game.DialogeSystem.Controller
{
    public class DialogueActivator : MonoBehaviour, IInteractable
    {
        public event Action<DialogueActivator> OnDialogueFinished;
        [SerializeField] private DialogeObject dialogueObject;
        [SerializeField] private string npcName = "NPC";
        private DialogueHintUI hintUI;

        public void UpdateDialogueObject(DialogeObject dialogeObject)
        {
            this.dialogueObject = dialogeObject;
        }

        private void Awake()
        {
            hintUI = FindObjectOfType<DialogueHintUI>();
        }

        public void Interact(PlayerController player){
            if (TryGetComponent(out DialogueResponceEvents responceEvents) && responceEvents.DialogeObject == dialogueObject)
            {
                player.DialogeUI.AddResponceEvents(responceEvents.Events);
            }
            player.DialogeUI.ShowDialogue(dialogueObject);
            player.DialogeUI.OnDialogueClosed += HandleDialogueClosed;
        }


        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Player") && other.TryGetComponent(out PlayerController player)){
                player.Interactable = this;
                hintUI.ShowHint(npcName);
            }
        }
    
        private void OnTriggerExit2D(Collider2D other) {
            if (other.gameObject.CompareTag("Player") && other.TryGetComponent(out PlayerController player)){
                if(player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this){
                    player.Interactable = null;
                    hintUI.HideHint();
                }
            }
        }
        private void HandleDialogueClosed()
        {
            OnDialogueFinished?.Invoke(this);
            PlayerController player = FindFirstObjectByType<PlayerController>();
            player.DialogeUI.OnDialogueClosed -= HandleDialogueClosed;
        }
    }
}