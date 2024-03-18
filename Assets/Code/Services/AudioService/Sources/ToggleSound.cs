using System.Collections;
using Code.Services.CoroutineRunner;
using UnityEngine;
using Zenject;

namespace Code.Services.AudioService.Sources
{
    public class ToggleSound : MonoBehaviour
    {
        [SerializeField] private AudioClip _audioClip;
        
        private AudioSource _audioSource;
        private ICoroutineRunner _coroutineRunner;

        [Inject]
        private void Construct(ICoroutineRunner coroutineRunner, AudioSource audioSource)
        {
            _coroutineRunner = coroutineRunner;
            _audioSource = audioSource;
        }

        public void Play()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
