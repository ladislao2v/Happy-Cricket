using UnityEngine;

namespace Code.Services.AudioService.Sources
{
    public class BackgroundMusic : SoundProvider
    {
        private void Start()
        {
            Play();
        }

        protected override void PlayClip(AudioSource audioSource, AudioClip clip)
        {
            audioSource.loop = true;
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
