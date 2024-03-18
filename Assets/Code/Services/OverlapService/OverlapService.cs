using Code.Views.Ball;
using UnityEngine;

namespace Code.Services.OverlapService
{
    public class OverlapService : MonoBehaviour
    {
        [SerializeField] private Transform _castCenter;
        [SerializeField] private int _radius;
        [SerializeField] private LayerMask _ballLayer;

        public bool IsOverlaped<T>(out T obj)
        {
            var colliders = Physics.OverlapSphere(_castCenter.position, _radius, _ballLayer);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out T component))
                {
                    obj = component;
                    return true;
                }
            }

            obj = default(T);
            return false;
        }
    }
}