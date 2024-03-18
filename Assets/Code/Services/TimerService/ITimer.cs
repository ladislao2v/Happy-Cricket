using System;
using System.Collections.Generic;
using Code.Services.PauseService;

namespace Code.Services.TimerService
{
    public interface ITimer : IPausable
    {
        event Action<int> Ticked;
        event Action TimeOut;

        public void Start();
    }
}