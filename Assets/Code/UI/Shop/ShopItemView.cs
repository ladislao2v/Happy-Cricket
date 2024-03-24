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
        
        private bool _isLock;

        public IItemConfig Config { get; private set; }

        public event Action<IShopItemView> BuyButtonClicked;
        public event Action<GameObject> DressButtonClicked;
        
        public void Construct(IItemConfig config, bool isLock)
        {
            Config = config;
            
            _backgroundImage.sprite = config.Background;
            _image.sprite = config.Sprite;
            _isLock = isLock;
        }
        
        public void MakeActive()
        {
            _image.gameObject.SetActive(false);
        }

        public void MakePassive()
        {
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
            if (_isLock)
            {
                DressButtonClicked?.Invoke(Config.Prefab);
                return;
            }
            
            BuyButtonClicked?.Invoke(this);
        }
    }
}