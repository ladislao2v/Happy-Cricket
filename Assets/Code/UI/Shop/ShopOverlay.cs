using System.Collections.Generic;
using System.Linq;
using Code.Services.Factories.ShopItemViewFactory;
using Code.Services.ShopService;
using Code.Services.SkinService;
using Code.Services.WalletService;
using UnityEngine;
using Zenject;

namespace Code.UI.Shop
{
    public class ShopOverlay : Overlay
    {
        private readonly List<IShopItemView> _shopItems = new();
        
        private IShopService _shopService;
        private IShopItemViewFactory _shopItemViewFactory;
        private ISkinService _skinService;
        private IWalletService _walletService;

        [Inject]
        private void Construct(IShopService shopService, IWalletService walletService,
            IShopItemViewFactory shopItemViewFactory, ISkinService skinService)
        {
            _walletService = walletService;
            _skinService = skinService;
            _shopItemViewFactory = shopItemViewFactory;
            _shopService = shopService;
        }

        private void OnEnable()
        {
            _shopService.Updated += OnUpdate;

            foreach (var shopItem in _shopItems)
            {
                shopItem.BuyButtonClicked += OnBuyButtonClicked;
                shopItem.DressButtonClicked += OnDressButtonClicked;
            }
            
            _walletService.MoneyChanged += OnMoneyChanged;
        }

        private void OnDisable()
        {
            _shopService.Updated -= OnUpdate;
            
            foreach (var shopItem in _shopItems)
            {
                shopItem.BuyButtonClicked -= OnBuyButtonClicked;
                shopItem.DressButtonClicked -= OnDressButtonClicked;
            }
            
            _walletService.MoneyChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged(int value)
        {
            foreach (var shopItem in _shopItems)
            {
                var config = shopItem.Config;
                
                if(value > config.Price)
                    shopItem.MakeActive();
                else
                    shopItem.MakePassive();
            }
        }

        private void OnDressButtonClicked(GameObject skin)
        {
            _skinService.Dress(skin);
        }

        public void Load()
        {
            foreach (var pair in _shopService.Items)
                _shopItems.Add(_shopItemViewFactory.Create(pair.Key, pair.Value, transform));
        }

        private void OnUpdate()
        {
            var keys = _shopService.Items.Keys.ToArray();
            var values = _shopService.Items.Values.ToArray();
            
            for(int i = 0; i < _shopItems.Count; i++)
                _shopItems[0].Construct(keys[i], values[i]);
        }

        private void OnBuyButtonClicked(IShopItemView view)
        {
            var config = view.Config;
            
            if (_shopService.Items[config])
                _skinService.Dress(config.Prefab);
            
            if(_shopService.TryBuy(config) == false)
                return;

            _skinService.Dress(config.Prefab);
        }
    }
}