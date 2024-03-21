using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Code.UI
{
    [RequireComponent(typeof(Button))]
    public class CustomButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void OnValidate() => 
            _button ??= GetComponent<Button>();

        public void SetAvailability(bool isLock)
        { 
            _button.interactable = isLock;
        }

        public void Subscribe(UnityAction action) => 
            _button.onClick.AddListener(action);

        public void Unsubscribe(UnityAction action) => 
            _button.onClick.AddListener(action);
    }
}