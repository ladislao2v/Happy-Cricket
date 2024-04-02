using Code.Services.StaticDataService.Configs;
using Code.UI.Shop;
using UnityEngine;
using Zenject;

namespace Code.Services.Factories.ShopItemViewFactory
{
    public class ShopItemViewFactory : IShopItemViewFactory
    {
        private readonly DiContainer _diContainer;
        private readonly ShopItemView _prefab;

        public ShopItemViewFactory(DiContainer diContainer, ShopItemView prefab)
        {
            _diContainer = diContainer;
            _prefab = prefab;
        }

        public IShopItemView Create(ItemConfig config, bool isLock, Transform container)
        {
            var view = _diContainer
                .InstantiatePrefabForComponent<ShopItemView>(_prefab, container);
            
            view.Construct(config, isLock);
            view.transform.SetParent(container);

            return view;
        }
    }
}