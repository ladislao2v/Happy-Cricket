using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.DailyReward
{
    public class BonusView : MonoBehaviour
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private int _bonus;
        [SerializeField] private Color _color;
        public int Bonus => _bonus;

        private void OnValidate()
        {
            _backgroundImage ??= GetComponent<Image>();
        }

        public void MakeActive()
        {
            _backgroundImage.material.color = Color.white;
        }

        public void MakeDisactive()
        {
            _backgroundImage.material.color = _color;
        }
    }
}