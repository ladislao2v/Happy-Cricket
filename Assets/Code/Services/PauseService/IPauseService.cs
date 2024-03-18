using System;
using System.Collections.Generic;

namespace Code.Services.PauseService
{
    public interface IPauseService
    {
        void Resume();
        void Pause();

        void Add(IPausable pausable);
    }

    public class PauseService : IPauseService
    {
        private readonly List<IPausable> _pausables = new();

        private bool _isPaused = false;

        public void Resume()
        {
            if(_isPaused == false)
                return;

            foreach (var pauseble in _pausables)
            {
                pauseble.OnResume();
            }

            _isPaused = false;
        }

        public void Pause()
        {
            if(_isPaused)
                return;

            foreach (var pauseble in _pausables)
            {
                pauseble.OnPause();
            }

            _isPaused = true;
        }

        public void Add(IPausable pausable)
        {
            if (_pausables.Contains(pausable))
                return;
            
            _pausables.Add(pausable);
        }
    }
}