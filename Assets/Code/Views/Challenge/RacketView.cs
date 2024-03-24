using System;
using Code.Services.HealthService;
using Code.Services.PauseService;
using Code.Services.ScoreService;
using Code.Views.Ball;
using UnityEngine;
using Zenject;

namespace Code.Views.Challenge
{
    public class RacketView : MonoBehaviour, IPausable
    {
        private bool _isPaused;
        private IScoreService _scoreService;

        [Inject]
        private void Construct(IScoreService scoreService)
        {
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