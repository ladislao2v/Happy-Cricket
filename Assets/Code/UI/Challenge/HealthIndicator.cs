using UnityEngine;

namespace Code.UI.Challenge
{
    public class HealthIndicator : MonoBehaviour
    {
        [SerializeField] private GameObject _indicator;

        public void Show()
        {
            _indicator.SetActive(true);
        }

        public void Hide()
        {
            _indicator.SetActive(false);
        }
    }
}