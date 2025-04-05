using Game.RoomSystem.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.RoomSystem
{
    public class RoomManager : MonoBehaviour
    {
        public RoomData initialRoom;
        public Transform spawnPoint;
        public Events events;
        public ScreenFade screenFade;
        private GameObject currentRoom;
        private bool isSpawning;
        private bool isRoomAvailable = false;

        void Start()
        {
            SpawnRoom(initialRoom);
        }
        public void SpawnNextRoom()
        {
            if (isSpawning) return;
            RoomData nextData = EvualateTransitions();
            if (nextData != null)
            {
                isSpawning = true;
                isRoomAvailable = false;
                BGChanger bgChanger = FindObjectOfType<BGChanger>();
                bgChanger?.OnRoomChanged();
                screenFade.FadeOutAndIn(() =>
                {
                    if (currentRoom != null)
                    {
                        Destroy(currentRoom);

                    }
                    GameObject nextRoom = Instantiate(nextData.roomPrefab, nextData.spawnPosition, Quaternion.identity);
                    RoomController rc = nextRoom.GetComponent<RoomController>();
                    rc.Initialize(this, nextData);
                    currentRoom = nextRoom;
                    PlayerController player = FindObjectOfType<PlayerController>();
                    player.Teleport(nextData.playerSpawnPosition);
                    player.ForceMovement(Vector2.up, 0.5f);
                    isSpawning = false;
                });

            }
        }

        public bool IsNextRoomAvaliable()
        {
            isRoomAvailable = EvualateTransitions() != null;
            return isRoomAvailable;
        }

        RoomData EvualateTransitions()
        {
            if (currentRoom == null) return null;
            RoomController rc = currentRoom.GetComponent<RoomController>();
            if (rc == null || rc.roomData  == null) return null;
            foreach (var transition in rc.roomData.transitions)
            {
                if (CheckTransitioncondition(transition.transitionId))
                {
                    return transition.nextRoom;
                }
            }
            return null;
        }
        bool CheckTransitioncondition(string id)
        {
            if (events == null) return false; 

            return id switch
            {
                "ROOM_1" => events.IsRoom_ONE_Ready(),
                "ROOM_2" => events.IsRoom_TWO_Ready(),
                "ROOM_4" => events.IsRoom_FOUR_Ready(),
                "ROOM_5" => events.IsRoom_FIVE_Ready(),
                "ROOM_6" => events.IsRoom_SIX_Ready(),
                "ROOM_9" => events.IsRoom_NINE_Ready(),
                "ROOM_10" => events.IsRoom_TEN_Ready(),
                "ROOM_11" => events.IsRoom_ELEVEN_Ready(),
                "ROOM_12" => events.IsRoom_TWELVE_Ready(),
                "ROOM_13" => events.IsRoom_THIRTEEN_Ready(),
                "ROOM_14" => events.IsRoom_FOURTEEN_Ready(),
                "ROOM_18" => events.IsRoom_EIGHTEEN_Ready(),
                "ROOM_19" => events.IsRoom_NINETEEN_Ready(),
                "ROOM_20" => events.IsRoom_TWENTY_Ready(),
                "ROOM_21" => events.IsRoom_TWENTY_ONE_Ready(),
                "ROOM_22" => events.IsRoom_TWENTY_TWO_Ready(),
                "ROOM_23" => events.IsRoom_TWENTY_THREE_Ready(),
                "ROOM_24" => events.IsRoom_TWENTY_FOUR_Ready(),
                "ROOM_27" => events.IsRoom_TWENTY_SEVEN_Ready(),
                "ROOM_28" => events.IsRoom_TWENTY_EIGHT_Ready(),
                "ROOM_29" => events.IsRoom_TWENTY_NINE_Ready(),
                "ROOM_30" => events.IsRoom_THIRTY_Ready(),
                "ROOM_31" => events.IsRoom_THIRTY_ONE_Ready(),
                "ROOM_34" => events.IsRoom_THIRTY_FOUR_Ready(),
                "END_1" => events.IsEnding1_Ready(),
                "END_2" => events.IsEnding2_Ready(),
                "END_3" => events.IsEnding3_Ready(),
                "END_4" => events.IsEnding4_Ready(),
                "END_5" => events.IsEnding5_Ready(),
                _ => false,
            };
        }
        void SpawnRoom(RoomData data)
        {
            currentRoom = Instantiate(data.roomPrefab, data.spawnPosition, Quaternion.identity);
            RoomController rc = currentRoom.GetComponent<RoomController>();
            rc.Initialize(this, data);
            RoomExit exit = currentRoom.GetComponentInChildren<RoomExit>();
            exit.roomManager = this;
            PlayerController player = FindObjectOfType<PlayerController>();
            player.Teleport(data.playerSpawnPosition);
        }
    }
}
