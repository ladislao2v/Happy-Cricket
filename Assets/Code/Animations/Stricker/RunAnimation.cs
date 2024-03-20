using Code.Services.MovementService;
using UnityEngine;

namespace Code.Animations.Stricker
{
    public class RunAnimation : MonoBehaviour
    {
        private static int IsRun = Animator.StringToHash(nameof(IsRun));
        
        [SerializeField] private SequenceMovement _strikerView;
        [SerializeField] private Animator _animator;

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
            _animator.SetBool(IsRun, value);
        }
    }
}