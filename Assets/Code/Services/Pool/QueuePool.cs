using System.Collections.Generic;
using Code.Services.Factories;
using Code.Services.Factories.MonoBehaviourFactory;
using UnityEngine;

namespace Code.Services.Pool
{
    public class QueuePool<T> : IPool<T> where T : MonoBehaviour
    {
        private readonly IFactory<T> _factory;
        private readonly Transform _container;
        private readonly Queue<T> _pool = new();
        private readonly List<T> _activeObjects = new();

        public QueuePool(IFactory<T> factory, Transform container = null, int count = 25)
        {
            _factory = factory;
            _container = container;

            for(int i = 0; i < count; i++)
                Return(CreateNew(Vector3.zero));
        }

        private T CreateNew(Vector3 position)
        {
            return _factory.Create(position, _container);
        }

        public T Get(Vector3 position)
        {
            if(_activeObjects.Count  > 0)
                Return(_activeObjects.Find(t => t.gameObject.activeInHierarchy == false));
            
            T item = _pool.Count > 0 ? _pool.Dequeue() : CreateNew(position);
            item.transform.position = position;
            item.gameObject.SetActive(true);
            _activeObjects.Add(item);

            return item;
        }

        public void Return(T item)
        {
            if(item == null)
                return;

            item.gameObject.SetActive(false);
            _pool.Enqueue(item);
            _activeObjects.Remove(item);
        }
    }
}
