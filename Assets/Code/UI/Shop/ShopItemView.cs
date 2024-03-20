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
        [SerializeField] private CustomButton _dressButton;
        [SerializeField] private Sprite _activeBackground;
        [SerializeField] private Sprite _passiveBackground;
        
        private Image _backgroundImage;

        public IItemConfig Config { get; private set; }

        public event Action<IShopItemView> BuyButtonClicked;
        public event Action<GameObject> DressButtonClicked;
        
        public void Construct(IItemConfig config, bool isLock)
        {
            Config = config;

            _nameText.text = Config.Name;
            _priceText.text = $"{Config.Price}";
            _logo.sprite = Config.Sprite;

            if (isLock)
            {
                _buyButton.gameObject.SetActive(false);
                _dressButton.gameObject.SetActive(true);
            }
        }

        private void Awake()
        {
            _backgroundImage = GetComponent<Image>();
        }
        
        public void MakeActive()
        {
            _buyButton.gameObject.SetActive(true);
            _backgroundImage.sprite = _activeBackground;
        }

        public void MakePassive()
        {
            _buyButton.gameObject.SetActive(false);
            _backgroundImage.sprite = _passiveBackground;
        }

        private void OnEnable()
        {
            _buyButton.Subscribe(OnBuyButtonClicked);
            _dressButton.Subscribe(OnDressButtonClicked);
        }

        public void OnDisable()
        {
            _buyButton.Unsubscribe(OnBuyButtonClicked);
            _dressButton.Unsubscribe(OnDressButtonClicked);
        }

        private void OnDressButtonClicked() => 
            DressButtonClicked?.Invoke(Config.Prefab);

        private void OnBuyButtonClicked() => 
            BuyButtonClicked?.Invoke(this);
    }
}