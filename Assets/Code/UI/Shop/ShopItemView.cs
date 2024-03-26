using System;
using Code.Services.StaticDataService.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Shop
{
    public class ShopItemView : Overlay, IShopItemView
    {
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Image _image;
        [SerializeField] private CustomButton _buyButton;
        
        private bool _isOpen;

        public IItemConfig Config { get; private set; }

        public event Action<IShopItemView> BuyButtonClicked;
        public event Action<IItemConfig> DressButtonClicked;
        
        public void Construct(IItemConfig config, bool isOpen)
        {
            Config = config;
            
            _backgroundImage.sprite = config.Background;
            _image.sprite = config.Sprite;
            _isOpen = isOpen;
            
            if(_isOpen)
                MakeActive();
        }
        
        public void MakeActive()
        {
            _image.gameObject.SetActive(false);
        }

        public void MakePassive()
        {
            if(_isOpen)
                return;
            
            _image.gameObject.SetActive(true);
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
            if (_isOpen)
            {
                DressButtonClicked?.Invoke(Config);
                return;
            }
            
            BuyButtonClicked?.Invoke(this);
        }
    }
}