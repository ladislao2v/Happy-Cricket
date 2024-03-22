using Code.Services.PauseService;
using UnityEngine;

namespace Code.Views.Ball
{
    public class ChallengeBallView : MonoBehaviour, IBallView, IPausable
    {
        [SerializeField] private float _force = 2;
        
        private Rigidbody2D _rigidbody;
        private Vector2 _lastVelocity;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Fly(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _force);
        }

        public void OnPause()
        {
            _lastVelocity = _rigidbody.velocity;
            _rigidbody.velocity = Vector2.zero;
        }

        public void OnResume()
        {
            _rigidbody.velocity = _lastVelocity;
        }
    }
}