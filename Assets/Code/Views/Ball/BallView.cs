using System.Collections;
using Code.Services.CoroutineRunner;
using UnityEngine;
using Zenject;

namespace Code.Views.Ball
{
    public class BallView : MonoBehaviour, IBallView
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private ForceMode _forceMode = ForceMode.Impulse;
        [SerializeField] private float _lifeTime = 3f;

        private ICoroutineRunner _coroutineRunner;
        private Rigidbody _rigidbody;
        private WaitForSeconds _delay;

        [Inject]
        private void Construct(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _delay = new WaitForSeconds(_lifeTime);
        }

        public void Fly(Vector3 direction)
        {
            _rigidbody.velocity = Vector3.zero;
            
            _rigidbody.AddForce(direction * _speed, _forceMode);

            _coroutineRunner.StartCoroutine(Hide());
        }

        private IEnumerator Hide()
        {
            yield return _delay;
            
            gameObject?.SetActive(false);
        }
    }
}