using UnityEngine;
using Zenject;

namespace Code.Services.Factories.PoolFactory
{
    public class PoolFactory<TItem> : IPoolFactory<TItem> where TItem : MonoBehaviour
    {
        private readonly DiContainer _diContainer;
        private readonly TItem[] _prefabs;

        public PoolFactory(DiContainer diContainer, params TItem[] prefabs)
        {
            _diContainer = diContainer;
            _prefabs = prefabs;
        }

        public TItem Create(Vector3 position, Transform parent = null)
        {
            var instance = _diContainer.InstantiatePrefabForComponent<TItem>(
                _prefabs[Random.Range(0, _prefabs.Length)],
                parent
            );

            return instance;
        }

        public TItem Create(Transform parent = null) => 
            Create(Vector3.zero, parent);
    }
}