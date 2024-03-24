using System.Collections.Generic;
using Code.StateMachine.States;
using UnityEngine;

namespace Code.UI.Challenge
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private List<HealthIndicator> _hearts;

        public void OnHealthChanged(int value)
        {
            if (value == 0)
            {
                gameObject.SetActive(false);
                return;
            }

            _hearts[value - 1].Hide();
        }
    }
}