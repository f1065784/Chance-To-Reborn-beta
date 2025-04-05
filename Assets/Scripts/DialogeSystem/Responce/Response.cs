using System;
using System.Collections;
using Game.DialogeSystem.Data;
using UnityEngine;
namespace Game.DialogeSystem.Responses{

    [System.Serializable]
    public class Response{
        [SerializeField] private string responseText;
        [SerializeField] private DialogeObject dialogeObject;

        public string ResponceText=> responseText;

        public DialogeObject DialogeObject => dialogeObject;
        
    }
}