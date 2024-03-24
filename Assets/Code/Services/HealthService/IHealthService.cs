using System;

namespace Code.Services.HealthService
{
    public interface IHealthService
    {
        int Health { get; }
        event Action<int> HealthChanged;
        event Action Died;
        public void Receive();
    }
}