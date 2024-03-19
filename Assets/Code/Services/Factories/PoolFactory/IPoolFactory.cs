using UnityEngine;

namespace Code.Services.Factories.PoolFactory
{
    public interface IPoolFactory<TObject> where TObject : MonoBehaviour
    {
        public TObject Create(Vector3 position, Transform parent = null);
        public TObject Create(Transform parent = null);
    }
}