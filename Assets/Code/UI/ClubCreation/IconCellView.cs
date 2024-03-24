using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.UI.ClubCreation
{
    public class IconCellView : CustomButton
    {
        [SerializeField] private Sprite _icon;
        
        private int _index;

        public event Action<int> Clicked;

        public void SetIndex(int index)
        {
            _index = index;
        }

        private void OnEnable()
        {
            Subscribe(OnButtonClicked);
        }

        private void OnDisable()
        {
            Unsubscribe(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            Clicked?.Invoke(_index);
        }
    }
}