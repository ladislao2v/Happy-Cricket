using System;
using Code.Services.Pool;
using Code.Views.Ball;
using UnityEngine;
using Zenject;

namespace Code.Views.Players
{
    public class PitcherView : MonoBehaviour, IPlayer
    {
        [SerializeField] private Transform _hand;

        private IPool<BallView> _pool;

        public event Action Swung;
        public event Action Throwed;
        public event Action Won;


        [Inject]
        private void Construct(IPool<BallView> pool)
        {
            _pool = pool;
        }

        public void Swing()
        {
            Swung?.Invoke();
        }

        public void Throw()
        {
            var ball = _pool.Get(_hand.position);

            ball.Fly(_hand.forward);
            
            Throwed?.Invoke();
        }

        public void Win()
        {
            Won?.Invoke();
        }
    }
}