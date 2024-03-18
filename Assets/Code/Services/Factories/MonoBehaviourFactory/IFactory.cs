using UnityEngine;

namespace Code.Services.Factories.MonoBehaviourFactory
{
    public interface IFactory<TObject> where TObject : MonoBehaviour
    {
        public TObject Create(Vector3 position, Transform parent = null);
        public TObject Create(Transform parent = null);
    }
}