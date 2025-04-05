using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.SelectionSystem.Object
{
    [CreateAssetMenu(menuName = "DialogeSystem/SelectionObject")]

    public class SelectionObject : ScriptableObject
    {
        [SerializeField][TextArea] private string question;
        [SerializeField] private string answer1;
        [SerializeField] private string answer2;
        [SerializeField] private string answer3;
        [SerializeField] private UnityEvent onAnswer1Selected;
        [SerializeField] private UnityEvent onAnswer2Selected;
        [SerializeField] private UnityEvent onAnswer3Selected;
        public bool hasOneOption = false;

        public string Question => question;
        public string Answer1 => answer1;
        public string Answer2 => answer2;
        public string Answer3 => answer3;
        public UnityEvent OnAnswer1Selected => onAnswer1Selected;
        public UnityEvent OnAnswer2Selected => onAnswer2Selected;
        public UnityEvent OnAnswer3Selected => onAnswer3Selected;
    }
}
