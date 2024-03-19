using System.Collections.Generic;
using System.Linq;
using Code.Services.Factories.ShopItemViewFactory;
using Code.Services.ShopService;
using Zenject;

namespace Code.UI.Shop
{
    public class ShopOverlay : Overlay
    {
        private readonly List<IShopItemView> _shopItems = new();
        
        private IShopService _shopService;
        private IShopItemViewFactory _shopItemViewFactory;

        [Inject]
        private void Construct(IShopService shopService,
            IShopItemViewFactory shopItemViewFactory)
        {
            _shopItemViewFactory = shopItemViewFactory;
            _shopService = shopService;
        }

        private void OnEnable()
        {
            _shopService.Updated += OnUpdate;
        }

        private void OnDisable()
        {
            _shopService.Updated -= OnUpdate;
        }

        public void Load()
        {
            foreach (var pair in _shopService.Items)
                _shopItems.Add(_shopItemViewFactory.Create(pair.Key, pair.Value, transform));
        }

        public void OnUpdate()
        {
            var keys = _shopService.Items.Keys.ToArray();
            var values = _shopService.Items.Values.ToArray();
            
            for(int i = 0; i < _shopItems.Count; i++)
                _shopItems[0].Construct(keys[i], values[i]);
        }
    }
}