using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Game.DialogeSystem.Data;
using Game.DialogeSystem.Responses;

public class DialogueResponceEvents : MonoBehaviour
{
    [SerializeField] private DialogeObject dialogeObject;
    [SerializeField] private ResponceEvent[] events;
    public DialogeObject DialogeObject => dialogeObject;
    public ResponceEvent[] Events => events;

    public void OnValidate()
    {
        if (dialogeObject == null) return;
        if (dialogeObject.Responses == null) return;
        if (events != null && events.Length == dialogeObject.Responses.Length) return;

        if (events == null)
        {
            events = new ResponceEvent[dialogeObject.Responses.Length];
        }
        else
        {
            Array.Resize(ref events, dialogeObject.Responses.Length);
        }

        for (int i = 0; i < dialogeObject.Responses.Length; i++)
        {
            Response response = dialogeObject.Responses[i];
            if (events[i].name != null)
            {
                events[i].name = response.ResponceText;
                continue;
            }
            events[i] = new ResponceEvent() {name = response.ResponceText};
        }
    }
}
