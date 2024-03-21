using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.ClubCreation
{
    public class ClubIconSelector : MonoBehaviour
    {
        [SerializeField] private Image _selectedIconView;
        [SerializeField] private List<IconCellView> _icons;

        public Sprite SelectedIcon { get; private set; }

        public void Show()
        {
            foreach (var iconCellView in _icons)
            {
                iconCellView.Subscribe(OnCellIconClicked);
            }
        }

        public void Hide()
        {
            foreach (var iconCellView in _icons)
            {
                iconCellView.Unsubscribe(OnCellIconClicked);
            }
        }

        private void OnCellIconClicked(Sprite sprite)
        {
            SelectedIcon = sprite;
            _selectedIconView.sprite = sprite;
        }
    }

    public class IconCellView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private CustomButton _customButton;

        public event Action<Sprite> Clicked;

        public void Subscribe(Action<Sprite> action)
        {
            _customButton.Subscribe(OnButtonClicked);
            Clicked += action;
        }

        public void Unsubscribe(Action<Sprite> action)
        {
            _customButton.Unsubscribe(OnButtonClicked);
            Clicked -= action;
        }

        private void OnButtonClicked()
        {
            
            Clicked?.Invoke(_image.sprite);
        }
    }
}