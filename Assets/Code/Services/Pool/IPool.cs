using UnityEngine;

namespace Code.Services.Pool
{
    public interface IPool<T> where T : MonoBehaviour
    {
        public T Get(Vector3 position);
    }
}