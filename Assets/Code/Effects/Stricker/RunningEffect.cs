using System;
using Code.Views.Stricker;
using UnityEngine;

namespace Code.Effects.Stricker
{
    public class RunningEffect : MonoBehaviour
    {
        [SerializeField] private StrikerView _strikerView;
        [SerializeField] private ParticleSystem _particleSystem;

        private void OnEnable()
        {
            _strikerView.Runned += OnRunned;
        }

        private void OnDisable()
        {
            _strikerView.Runned -= OnRunned;
        }

        private void OnRunned(bool value)
        {
            if(value)
                _particleSystem.Play();
            else
                _particleSystem.Stop();
        }
    }
}