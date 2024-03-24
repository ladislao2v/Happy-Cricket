using System.Collections.Generic;
using System.Linq;
using Code.Services.Factories.ShopItemViewFactory;
using Code.Services.ShopService;
using Code.Services.SkinService;
using Code.Services.WalletService;
using Code.StateMachine;
using Code.StateMachine.States;
using Code.UI.DailyReward;
using UnityEngine;
using Zenject;

namespace Code.UI.Shop
{
    public class ShopOverlay : Overlay, IBackableWindow
    {
        [SerializeField] private WalletView _walletView;
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private Transform _container;
        
        private readonly List<IShopItemView> _shopItems = new();
        
        private IShopService _shopService;
        private IShopItemViewFactory _shopItemViewFactory;
        private ISkinService _skinService;
        private IWalletService _walletService;
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(IShopService shopService, IWalletService walletService,
            IShopItemViewFactory shopItemViewFactory, ISkinService skinService, 
            IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _walletService = walletService;
            _skinService = skinService;
            _shopItemViewFactory = shopItemViewFactory;
            _shopService = shopService;
        }

        private void OnEnable()
        {
            _backButton.Subscribe(OnBackButtonClicked);
            _shopService.Updated += OnUpdate;

            foreach (var shopItem in _shopItems)
            {
                shopItem.BuyButtonClicked += OnBuyButtonClicked;
                shopItem.DressButtonClicked += OnDressButtonClicked;
            }
            
            _walletService.MoneyChanged += OnMoneyChanged;
            _walletService.MoneyChanged += _walletView.OnMoneyChanged;
            
            OnMoneyChanged(_walletService.Value);
            
            _walletView.OnMoneyChanged(_walletService.Value);
        }

        private void OnDisable()
        {
            _backButton.Unsubscribe(OnBackButtonClicked);
            _shopService.Updated -= OnUpdate;
            
            foreach (var shopItem in _shopItems)
            {
                shopItem.BuyButtonClicked -= OnBuyButtonClicked;
                shopItem.DressButtonClicked -= OnDressButtonClicked;
            }
            
            _walletService.MoneyChanged -= OnMoneyChanged;
            _walletService.MoneyChanged -= _walletView.OnMoneyChanged;
            _walletView.OnMoneyChanged(_walletService.Value);
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
                _shopItems.Add(_shopItemViewFactory.Create(pair.Key, pair.Value, _container));
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

        public void OnBackButtonClicked()
        {
            _stateMachine.Enter<SaveDataState>();
        }
    }
}