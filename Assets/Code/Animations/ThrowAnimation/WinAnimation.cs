using Code.Views.Players;
using UnityEngine;

namespace Code.Animations.ThrowAnimation
{
    public class WinAnimation : MonoBehaviour
    {
        private static int WinTrigger = Animator.StringToHash(nameof(WinTrigger));
        
        [SerializeField] private PitcherView _pitcherView;
        [SerializeField] private Animator _animator;

        private void OnEnable()
        {
            _pitcherView.Won += OnWon;
        }
        
        private void OnDisable()
        {
            _pitcherView.Won -= OnWon;
        }

        private void OnWon()
        {
            _animator.SetTrigger(WinTrigger);
        }
    }
}