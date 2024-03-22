using Code.Services.PauseService;
using Code.Views.Players;
using UnityEngine.InputSystem;

namespace Code.Services.InputService
{
    public interface IInputService: IPausable 
    {
        void Enable();
        void Disable();
    }

    public class InputService : IInputService
    {
        private readonly StrikerView _strikerView;
        private readonly InputMap _inputMap = new();
        private bool _isPaused;

        public InputService(StrikerView strikerView)
        {
            _strikerView = strikerView;
        }
        
        public void Enable()
        {
            _inputMap.Enable();
            _inputMap.Gameplay.Click.performed += OnClicked;
        }

        public void Disable()
        {
            _inputMap.Disable();
            _inputMap.Gameplay.Click.performed -= OnClicked;
        }

        private void OnClicked(InputAction.CallbackContext obj)
        {
            if(_isPaused)
                return;

            _strikerView.Swing();
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