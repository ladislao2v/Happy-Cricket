using System;
using Code.Services.OverlapService;
using Code.StateMachine;
using Code.StateMachine.States;
using Code.Views.Ball;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Code.Views.Stricker
{
    [RequireComponent(typeof(OverlapService))]
    public class StrikerView : MonoBehaviour, IPlayer
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;
        [SerializeField] private float _duration = 2f;
        [SerializeField] private float _rotateTime = 0.25f;
        
        private IStateMachine _stateMachine;
        private OverlapService _overlapService;
        private Transform _transform;

        public event Action Swung;
        public event Action Kicked;
        public event Action<bool> Runned;
        public event Action Losed;

        [Inject]
        private void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Awake()
        {
            _overlapService = GetComponent<OverlapService>();
            _transform = GetComponent<Transform>();
        }

        public void Swing()
        {
            Swung?.Invoke();
        }
        
        public void Kick()
        {
            if(_overlapService.IsOverlaped(out IBallView ballView))
            {
                var direction = 
                    transform.forward - transform.right + transform.up;
                
                ballView.Fly(direction);
                
                _stateMachine.Enter<ChangePositionState>();
                
                Kicked?.Invoke();
            }
        }

        public void Run(int count)
        {
            Sequence sequence = DOTween.Sequence();
            
            sequence.AppendInterval(_rotateTime);
            sequence.AppendCallback(() => Runned?.Invoke(true));
            

            for (int i = 0; i < count; i++)
            {
                sequence
                    .Append(_transform.DOMove(_endPoint.position, _duration))
                    .Append(_transform.DORotate(new Vector3(0, 90, 0), _rotateTime))
                    .Append(_transform.DOMove(_startPoint.position, _duration))
                    .Append(_transform.DORotate(new Vector3(0, -90, 0), _rotateTime));
            }

            sequence
                .AppendCallback(() => Runned?.Invoke(false))
                .AppendCallback(() => _stateMachine.Enter<PitcherThrowState>());
        }

        public void Lose()
        {
            Losed?.Invoke();
        }
    }
}