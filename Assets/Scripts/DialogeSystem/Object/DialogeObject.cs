using Game.DialogeSystem.Responses;
using Game.SelectionSystem.Object;
using UnityEngine;

namespace Game.DialogeSystem.Data{
    [CreateAssetMenu(menuName = "DialogeSystem/DialogeObject")]

    public class DialogeObject : ScriptableObject{
        [SerializeField] [TextArea] private string[] dialogue;
        [SerializeField] private Response[] responses;
        [SerializeField] private SelectionObject selectionObject;

        public string[] Dialogue => dialogue;

        public bool HasResponses => responses != null && responses.Length > 0;
        public Response[] Responses => responses;
        public bool HasSelection => selectionObject != null;
        public SelectionObject Selection => selectionObject;
    }
}