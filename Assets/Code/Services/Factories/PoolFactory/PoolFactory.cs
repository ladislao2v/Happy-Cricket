using Code.Services.PauseService;
using UnityEngine;
using Zenject;

namespace Code.Services.Factories.PoolFactory
{
    public class PoolFactory<TItem> : IPoolFactory<TItem> where TItem : MonoBehaviour
    {
        private readonly DiContainer _diContainer;
        private readonly TItem[] _prefabs;
        private readonly IPauseService _pauseService;

        public PoolFactory(IPauseService pauseService, DiContainer diContainer, TItem[] prefabs)
        {
            _diContainer = diContainer;
            _prefabs = prefabs;
            _pauseService = pauseService;
        }

        public TItem Create(Vector3 position, Transform parent = null)
        {
            var instance = _diContainer.InstantiatePrefabForComponent<TItem>(
                _prefabs[Random.Range(0, _prefabs.Length)],
                parent
            );
            
            if(instance is IPausable pausable)
                _pauseService.Add(pausable);

            return instance;
        }

        public TItem Create(Transform parent = null) => 
            Create(Vector3.zero, parent);
    }
}