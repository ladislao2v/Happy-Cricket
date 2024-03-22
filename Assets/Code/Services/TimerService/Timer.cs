using System;
using System.Collections;
using Code.Services.CoroutineRunner;
using Code.Services.PauseService;
using UnityEngine;
using Zenject;

namespace Code.Services.TimerService
{
    public class Timer : ITimer, IPausable
    {
        private bool _isPaused;
        private ICoroutineRunner _coroutineRunner;

        public event Action<int> Ticked;
        public event Action TimeOut;

        [Inject]
        private void Construct(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void Start(int time)
        {
            _coroutineRunner.StartCoroutine(Tick(time));
        }

        private IEnumerator Tick(int time)
        {
            float timer = 0f;
            
            while (timer < time)
            {
                if(_isPaused == false)
                    timer += Time.deltaTime;
                
                Ticked?.Invoke(time - (int)timer);
                yield return null;
            }
            
            TimeOut?.Invoke();
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