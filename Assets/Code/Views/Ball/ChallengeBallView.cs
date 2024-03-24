using System;
using Code.Services.PauseService;
using UnityEngine;

namespace Code.Views.Ball
{
    public class ChallengeBallView : MonoBehaviour, IBallView, IPausable
    {
        [SerializeField] private float _force = 2;
        
        private Rigidbody2D _rigidbody;
        private Vector2 _lastVelocity;
        private Vector3 _startPosition;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.gravityScale = 0;
            _startPosition = transform.position;
        }

        public void Fly(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _force);
        }

        public void Throw()
        {
            _rigidbody.gravityScale = 100;
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

        public void Return()
        {
            _startPosition = 
                new Vector3(_startPosition.x, _startPosition.y + _startPosition.y / 2, _startPosition.z);
            transform.position = _startPosition;
        }

        public void Stop()
        {
            gameObject.SetActive(false);
        }
    }
}