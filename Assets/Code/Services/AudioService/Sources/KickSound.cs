using System;
using Code.Views.Players;
using UnityEngine;

namespace Code.Services.AudioService.Sources
{
    public class KickSound : SoundProvider
    {
        [SerializeField] private StrikerView _strikerView;

        private void OnEnable()
        {
            _strikerView.Kicked += Play;
        }

        private void OnDisable()
        {
            _strikerView.Kicked -= Play;
        }

        protected override void PlayClip(AudioSource audioSource, AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}