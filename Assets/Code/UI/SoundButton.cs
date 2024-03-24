using Code.Services.AudioService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI
{
    public class SoundButton : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;
        [SerializeField] private Image _indicator;
        
        private IAudioService _audioService;

        [Inject]
        private void Construct(IAudioService audioService)
        {
            _audioService = audioService;
        }

        public void TurnOn()
        {
            _toggle.onValueChanged.AddListener(OnToggleClick);
            
            _toggle.isOn = _audioService.IsMute;
        }

        public void TurnOff()
        {
            _toggle.onValueChanged.RemoveListener(OnToggleClick);
        }

        private void OnToggleClick(bool isActive)
        {
            if (isActive == false)
            {
                _audioService.Enable();
            }
            else
            {
                _audioService.Disable();
            }
        }
    }
}
