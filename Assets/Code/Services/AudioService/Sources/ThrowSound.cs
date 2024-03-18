using System;
using Code.Views.Players;
using UnityEngine;

namespace Code.Services.AudioService.Sources
{
    public class ThrowSound : SoundProvider
    {
        [SerializeField] private PitcherView _pitcherView;

        private void OnEnable()
        {
            _pitcherView.Throwed += Play;
        }

        private void OnDisable()
        {
            _pitcherView.Throwed -= Play;
        }

        protected override void PlayClip(AudioSource audioSource, AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}