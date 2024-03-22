
using Code.UI.Settings;

namespace Code.StateMachine.States
{
    public class SettingsState : IState
    {
        private readonly SettingsOverlay _settingsOverlay;

        public SettingsState(SettingsOverlay settingsOverlay)
        {
            _settingsOverlay = settingsOverlay;
        }
        public void Enter()
        {
            _settingsOverlay.Show();
        }

        public void Exit()
        {
            _settingsOverlay.Hide();
        }
    }
}