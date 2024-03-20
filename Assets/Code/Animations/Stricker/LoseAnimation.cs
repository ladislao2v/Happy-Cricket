using System;
using Code.Views.Players;
using UnityEngine;

namespace Code.Animations.Stricker
{
    public class LoseAnimation : MonoBehaviour
    {
        private static int LoseTrigger = Animator.StringToHash(nameof(LoseTrigger));
        
        [SerializeField] private StrikerView _strikerView;
        [SerializeField] private Animator _animator;

        private void OnEnable()
        {
            _strikerView.Losed += OnLosed;
        }

        private void OnLosed()
        {
            _animator.SetTrigger(LoseTrigger);
        }
    }
}