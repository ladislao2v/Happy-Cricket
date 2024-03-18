using System;
using Code.StateMachine.States;
using Code.Views.Players;
using UnityEngine;

namespace Code.Animations.ThrowAnimation
{
    public class ThrowAnimation : MonoBehaviour
    {
        private static readonly int ThrowTrigger = Animator.StringToHash(nameof(ThrowTrigger));
        
        [SerializeField] private PitcherView _pitcherView;
        [SerializeField] private Animator _animator;

        private void OnEnable()
        {
            _pitcherView.Swung += OnSwung;
        }

        private void OnDisable()
        {
            _pitcherView.Swung -= OnSwung;
        }

        private void OnSwung()
        {
            _animator.SetTrigger(ThrowTrigger);
        }

        private void OnHalfAnimationTrigger()
        {
            _pitcherView.Throw();
        }
    }
}