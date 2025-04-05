using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class ResponceEvent
{
    [HideInInspector] public string name;
    [SerializeField] private UnityEvent onPickedResponce;

    public UnityEvent OnPickedResponce => onPickedResponce;
}
