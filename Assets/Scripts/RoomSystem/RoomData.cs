using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Room/RoomData")]
public class RoomData : ScriptableObject
{
    public GameObject roomPrefab;
    public Vector3 spawnPosition;
    public Vector3 playerSpawnPosition;
    public RoomTransition[] transitions;
}
[System.Serializable]
public class RoomTransition
{
    public string transitionId;
    public RoomData nextRoom;
}
