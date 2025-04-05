using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.RoomSystem
{
    public class RoomExit : MonoBehaviour
    {
        public RoomManager roomManager;
        public Animator doorAnimator;
        private RoomTrasitionHintUI transitionHintUI;
        private bool isPlayerNear;
        private bool isDoorOpen = false;
        private void Start()
        {
            roomManager = GameObject.Find("RoomManager").GetComponent<RoomManager>();
            transitionHintUI = FindObjectOfType<RoomTrasitionHintUI>();
        }
        private void Update()
        {
            if (isPlayerNear && Input.GetKeyDown(KeyCode.Q)){
                if (roomManager.IsNextRoomAvaliable())
                {
                    roomManager.SpawnNextRoom();
                    doorAnimator.SetTrigger("Close");
                    isDoorOpen = false;
                    transitionHintUI.HideHint();
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                
                isPlayerNear = true;
                if (roomManager.IsNextRoomAvaliable())
                {
                    doorAnimator.SetTrigger("Open");
                    transitionHintUI.ShowHint();
                    isDoorOpen = true;
                    Debug.Log("Player is near the door and can enter the next room.");  
                }
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                
                isPlayerNear = false;
                if (isDoorOpen)
                {
                    doorAnimator.SetTrigger("Close");
                    isDoorOpen = false;
                    transitionHintUI.HideHint();
                    Debug.Log("Player is leaving the door area.");
                }
            }
        }
    }
}
