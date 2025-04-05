using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(DialogueResponceEvents))]
public class DialogueResponceEventsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        DialogueResponceEvents responceEvents = (DialogueResponceEvents)target;
        if (GUILayout.Button("Refresh"))
        {
            responceEvents.OnValidate();
        }
    }
}
