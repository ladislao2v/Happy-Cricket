using Code.Views.Players;
using UnityEngine;

namespace Code.Effects.Stricker
{
    public class KickEffect : MonoBehaviour
    {
        [SerializeField] private StrikerView _strikerView; 
        [SerializeField] private ParticleSystem _effect;

        private void OnEnable()
        {
            _strikerView.Kicked += _effect.Play;
        }

        private void OnDisable()
        {
            _strikerView.Kicked -= _effect.Play;
        }
    }
}