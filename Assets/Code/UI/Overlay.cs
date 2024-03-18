using UnityEngine;

namespace Code.UI
{
    public class Overlay : MonoBehaviour
    {
        public void Show()
        {
            gameObject?.SetActive(true);
        }

        public void Hide()
        {
            gameObject?.SetActive(false);
        }
    }
}