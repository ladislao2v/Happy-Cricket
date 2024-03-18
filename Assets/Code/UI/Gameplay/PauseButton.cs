using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Code.UI.Gameplay
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;

        public void Subscribe(UnityAction<bool> unityAction)
        {
            _toggle.onValueChanged.AddListener(unityAction);
        }

        public void Unsubscribe(UnityAction<bool> unityAction)
        {
            _toggle.onValueChanged.AddListener(unityAction);
        }
    }
}