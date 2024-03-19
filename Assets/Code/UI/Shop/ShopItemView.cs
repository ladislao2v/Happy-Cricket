using System;
using Code.Services.StaticDataService.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Shop
{
    public class ShopItemView : Overlay, IShopItemView
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Image _logo;
        [SerializeField] private CustomButton _buyButton;

        private IItemConfig _config;

        public event Action<IItemConfig> Clicked; 
        
        public void Construct(IItemConfig config, bool isLock)
        {
            _config = config;

            _nameText.text = _config.Name;
            _priceText.text = $"{_config.Price}";
            _logo.sprite = _config.Sprite;
        }

        private void OnEnable()
        {
            _buyButton.Subscribe(OnBuyButtonClicked);
        }

        public void OnDisable()
        {
            _buyButton.Unsubscribe(OnBuyButtonClicked);
        }

        private void OnBuyButtonClicked()
        {
            Clicked?.Invoke(_config);
        }
    }
}