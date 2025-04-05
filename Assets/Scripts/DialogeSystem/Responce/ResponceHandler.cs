using UnityEngine;
using UnityEngine.UI;
using Game.DialogeSystem.UI;
using TMPro;
using System.Collections.Generic;

namespace Game.DialogeSystem.Responses{
    public class ResponceHandler : MonoBehaviour{
        [SerializeField] private RectTransform responseBox;
        [SerializeField] private RectTransform responseButtonTemplate;
        [SerializeField] private RectTransform responseContainer;

        private DialogeUI dialogeUI;
        private ResponceEvent[] responceEvents;
        private List<GameObject> tempResponseButtons = new List<GameObject>();

        private void Start(){
            dialogeUI = GetComponent<DialogeUI>();
        }
        public void AddResponceEvents(ResponceEvent[] responceEvents)
        {
            this.responceEvents = responceEvents;
        }
        public void ShowResponses(Response[] responses){
            float responseBoxHeight = 0f;

            for (int i = 0; i < responses.Length; i++){
                Response response = responses[i];
                int responceIndex = i;
                GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
                responseButton.gameObject.SetActive(true);
                responseButton.GetComponentInChildren<TMP_Text>().text = response.ResponceText;
                responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response, responceIndex));
                tempResponseButtons.Add(responseButton);
                responseBoxHeight += responseButtonTemplate.sizeDelta.y + 10;
            }

            responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
            responseBox.gameObject.SetActive(true);
        }
        private void OnPickedResponse(Response response, int responceIndex){
            responseBox.gameObject.SetActive(false);
            
            foreach(GameObject responseButton in tempResponseButtons){
                Destroy(responseButton);
            }
            tempResponseButtons.Clear();

            if (responceEvents != null && responceIndex <= responceEvents.Length)
            {
                responceEvents[responceIndex].OnPickedResponce?.Invoke();
            }
            
            responceEvents = null;
            if (response.DialogeObject)
            {
                dialogeUI.ShowDialogue(response.DialogeObject);
            }
            else
            {
                dialogeUI.CloseDialogeBox();
            }
        }
    }
}