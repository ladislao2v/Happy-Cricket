using System;
using Code.StateMachine;
using Code.StateMachine.States;
using Code.Views.Players;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Code.Services.MovementService
{
    public class SequenceMovement : MonoBehaviour, IMovementService
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;
        [SerializeField] private float _duration = 1.65f;
        [SerializeField] private float _rotateTime = 0.35f;

        private Transform _transform;
        private IStateMachine _stateMachine;

        public event Action<bool> Runned;

        [Inject]
        private void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Awake()
        {
            _transform = GetComponent<Transform>();
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
    }
}