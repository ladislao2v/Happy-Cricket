
using System;
using Code.StateMachine.States;

namespace Code.Services.HealthService
{
    public class HealthService : IHealthService
    {
        private int _health = 3;
        public int Health => _health;
        public event Action<int> HealthChanged;
        public event Action Died;

        public void Receive()
        {
            _health--;
            HealthChanged?.Invoke(_health);
            
            if(_health < 1)
                Died?.Invoke();
        }
    }
}