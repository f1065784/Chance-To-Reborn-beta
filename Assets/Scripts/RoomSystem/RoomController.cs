using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.RoomSystem
{
    public class RoomController : MonoBehaviour
    {
        [HideInInspector]public RoomData roomData;
        private RoomManager roomManager;
        public void Initialize(RoomManager manager, RoomData data)
        {
            roomManager = manager;
            roomData = data;
        }
    }
}
