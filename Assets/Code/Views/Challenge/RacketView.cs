using System;
using Code.Services.PauseService;
using Code.Views.Ball;
using UnityEngine;

namespace Code.Views.Challenge
{
    public class RacketView : MonoBehaviour, IPausable
    {
        private bool _isPaused;

        private void Update()
        {
            if(_isPaused)
                return;
            
            transform.position += Input.mousePosition;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if(col.collider.TryGetComponent(out IBallView ballView))
                ballView.Fly(transform.up);
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