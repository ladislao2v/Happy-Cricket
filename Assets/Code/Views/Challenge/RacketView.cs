using System;
using Code.Services.HealthService;
using Code.Services.PauseService;
using Code.Services.ScoreService;
using Code.Services.StatsService;
using Code.Views.Ball;
using UnityEngine;
using Zenject;

namespace Code.Views.Challenge
{
    public class RacketView : MonoBehaviour, IPausable
    {
        private bool _isPaused;
        private IScoreService _scoreService;
        private IStatsService _statsService;

        [Inject]
        private void Construct(IScoreService scoreService
            , IStatsService statsService)
        {
            _statsService = statsService;
            _scoreService = scoreService;
        }

        private void Update()
        {
            if(_isPaused)
                return;
            
            if(gameObject.activeInHierarchy == false)
                return;

            transform.position = Input.mousePosition;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.collider.TryGetComponent(out IBallView ballView)) 
                return;
            
            ballView.Fly(Vector3.up);
            _scoreService.Add(1);
            _statsService.AddChallengeWin();
        }

        public void OnPause()
        {
            _isPaused = true;
        }

        public void OnResume()
        {
            _isPaused = false;
        }
    }
}