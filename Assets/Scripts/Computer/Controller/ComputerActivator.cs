using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.DialogeSystem.UI;
using Game.Computer;
namespace Game.Computer {
    public class ComputerActivator : MonoBehaviour
    {
        private DialogueHintUI dialogueHintUI;
        [SerializeField] private string _name = "computer";
        private bool isOpen = false;

        private void Start()
        {
            dialogueHintUI = FindObjectOfType<DialogueHintUI>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            dialogueHintUI.ShowHint(_name);
            isOpen = true;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isOpen = false;
                dialogueHintUI.HideHint();
            }
        }
        void Update()
        {
            if (isOpen == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject.Find("Computer").GetComponent<ComputerUI>().ShowSelection();
                    dialogueHintUI.HideHint();
                }
            }
        }
    }
}
