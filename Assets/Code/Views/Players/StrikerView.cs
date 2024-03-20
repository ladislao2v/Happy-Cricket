using System;
using Code.Services.OverlapService;
using Code.StateMachine;
using Code.StateMachine.States;
using Code.Views.Ball;
using UnityEngine;
using Zenject;

namespace Code.Views.Players
{
    public class StrikerView : MonoBehaviour, IPlayer
    {
        [SerializeField] private Transform _head;
        
        private IStateMachine _stateMachine;
        private IOverlapService _overlapService;
        private IMovementService _movementService;
        
        private GameObject _skin;

        public event Action Swung;
        public event Action Kicked;
        public event Action Losed;

        [Inject]
        private void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Awake()
        {
            _overlapService = GetComponent<IOverlapService>();
            _movementService = GetComponent<IMovementService>();
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
            _movementService.Run(count);
        }

        public void Lose()
        {
            Losed?.Invoke();
        }

        public void SetSkin(GameObject skin)
        {
            Destroy(_skin);

            _skin = Instantiate(skin, _head);
        }
    }
}