using Game.DialogeSystem.Controller;
using Game.SelectionSystem.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.SelectionSystem.UI;

public class SelectionController : MonoBehaviour
{
    [SerializeField] private DialogueActivator[] npcToTalkTo;
    [SerializeField] private SelectionObject selectionObject;
    private SelectionUI selectionUI;

    private HashSet<DialogueActivator> talkedToNPCs = new HashSet<DialogueActivator>();

    private void Start()
    {
        selectionUI = FindObjectOfType<SelectionUI>();
        foreach (var npc in npcToTalkTo)
        {
            npc.GetComponent<DialogueActivator>().OnDialogueFinished += HandleDialogueFinished;
        }
    }

    private void HandleDialogueFinished(DialogueActivator npc)
    {
        if (talkedToNPCs.Add(npc))
        {
            if (talkedToNPCs.Count >= npcToTalkTo.Length)
            {
                selectionUI.ShowSelection(selectionObject);
            }
        }
    }
}