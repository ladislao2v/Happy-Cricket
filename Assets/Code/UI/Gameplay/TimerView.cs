using TMPro;
using UnityEngine;

namespace Code.UI.Gameplay
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        public void Render(int value)
        {
            _text.text = value + "s";
        }
    }
}