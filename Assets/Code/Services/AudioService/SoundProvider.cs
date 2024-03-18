using UnityEngine;
using Zenject;

namespace Code.Services.AudioService
{
    public abstract class SoundProvider : MonoBehaviour
    {
        [SerializeField] private AudioClip _clip;
        
        private AudioSource _audioSource;

        [Inject]
        private void Construct(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        protected void Play()
        {
            PlayClip(_audioSource, _clip);
        }

        protected abstract void PlayClip(AudioSource audioSource, AudioClip clip);
    }
}
