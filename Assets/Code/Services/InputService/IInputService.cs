using Code.Views.Players;
using UnityEngine.InputSystem;

namespace Code.Services.InputService
{
    public interface IInputService
    {
        void Enable();
        void Disable();
    }

    public class InputService : IInputService
    {
        private readonly StrikerView _strikerView;
        private readonly InputMap _inputMap = new();

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
            _strikerView.Swing();
        }
    }
}