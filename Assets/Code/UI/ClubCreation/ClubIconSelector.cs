using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.ClubCreation
{
    public class ClubIconSelector : MonoBehaviour
    {
        [SerializeField] private Image _selectedIconView;
        [SerializeField] private List<IconCellView> _icons;
        [SerializeField] private List<Sprite> _sprites;

        public int SelectedIcon { get; private set; }

        public void Construct(int index)
        {
            _selectedIconView.sprite = _sprites[index];
        }

        public void Show()
        {
            int i = 0;
            _icons.ForEach(x => x.SetIndex(i++));
            
            foreach (var iconCellView in _icons)
            {
                iconCellView.gameObject.SetActive(true);
                iconCellView.Clicked += (OnCellIconClicked);
            }
        }

        public void Hide()
        {
            foreach (var iconCellView in _icons)
            {
                iconCellView.gameObject.SetActive(false);
                iconCellView.Clicked -= (OnCellIconClicked);
            }
        }

        private void OnCellIconClicked(int index)
        {
            SelectedIcon = index;
            _selectedIconView.sprite = _sprites[index];
        }
    }
}