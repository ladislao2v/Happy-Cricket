using Code.Views.Players;
using UnityEngine;

namespace Code.Effects.Pitcher
{
    public class ThrowEffect : MonoBehaviour
    {
        [SerializeField] private PitcherView _pitcherView;
        [SerializeField] private ParticleSystem _particleSystem;

        private void OnEnable()
        {
            _pitcherView.Throwed += _particleSystem.Play;
        }

        private void OnDisable()
        {
            _pitcherView.Throwed -= _particleSystem.Play;
        }
    }
}