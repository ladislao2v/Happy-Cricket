using System;
using Code.Views.Stricker;
using UnityEngine;

namespace Code.Animations.Stricker
{
    public class KickAnimation : MonoBehaviour
    {
        private static readonly int KickTrigger = Animator.StringToHash(nameof(KickTrigger));
        
        [SerializeField] private StrikerView _strikerView;
        [SerializeField] private Animator _animator;

        private void OnEnable()
        {
            _strikerView.Swung += OnSwung;
        }

        private void OnDisable()
        {
            _strikerView.Swung -= OnSwung;
        }

        private void OnSwung()
        {
            _animator.SetTrigger(KickTrigger);
        }

        private void OnHalfAnimationTrigger()
        {
            _strikerView.Kick();
        }
    }
}