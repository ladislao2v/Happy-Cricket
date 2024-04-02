using System;
using System.Collections.Generic;
using System.Net.Mail;
using Code.Services.OverlapService;
using Code.Services.ScoreService;
using Code.Services.SkinService;
using Code.Services.StatsService;
using Code.StateMachine;
using Code.StateMachine.States;
using Code.UI.Gameplay;
using Code.Views.Ball;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Code.Views.Players
{
    public class StrikerView : MonoBehaviour, IPlayer
    {
        [SerializeField] private HalfView _halfView;
        [SerializeField] private List<Skin> _skins;
        [SerializeField] private Transform _head;
        
        private IStateMachine _stateMachine;
        private IOverlapService _overlapService;
        private IMovementService _movementService;
        
        private IScoreService _scoreService;
        private IStatsService _statsService;
        private int _lastSkin;

        public event Action Swung;
        public event Action Kicked;
        public event Action Losed;

        [Inject]
        private void Construct(IStateMachine stateMachine, IScoreService scoreService, IStatsService statsService)
        {
            _statsService = statsService;
            _scoreService = scoreService;
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
                _statsService.AddHitCount();
            }
        }

        public void Run(int count)
        {
            if (_scoreService.CurrentThrow == 6)
                return;

            _movementService.Run(count, OnRun);
        }

        public void OnRun()
        {
            if (_scoreService.CurrentThrow == 3)
            {
                _halfView.gameObject.SetActive(true);
                Debug.Log("Half after hit");
                return;
            }
                
            _stateMachine.Enter<PitcherThrowState>();
        }


        public void Lose()
        {
            Losed?.Invoke();
        }

        public void SetSkin(int index)
        {
            if (_skins[_lastSkin] != null)
            {
                _skins[_lastSkin].gameObject.SetActive(false);
            }

            if (_skins[index] != null)
            {
                _skins[index].gameObject.SetActive(true);
            }

            _lastSkin = index;
        }
    }
}