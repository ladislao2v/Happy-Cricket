using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.DailyReward
{
    public class BonusView : MonoBehaviour
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private int _bonus;
        [SerializeField] private Sprite _blocked;
        [SerializeField] private Sprite _opened;
        public int Bonus => _bonus;

        private void OnValidate()
        {
            _backgroundImage ??= GetComponent<Image>();
        }

        public void MakeActive()
        {
            _backgroundImage.sprite = _opened;
        }

        public void MakeDisactive()
        {
            _backgroundImage.sprite = _blocked;
        }
    }
}