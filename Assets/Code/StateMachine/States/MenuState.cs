using Code.UI.Menu;

namespace Code.StateMachine.States
{
    public class MenuState : IState
    {
        private readonly MenuOverlay _menu;

        public MenuState(MenuOverlay menu)
        {
            _menu = menu;
        }
        
        public void Enter()
        {
            _menu.Show();
        }

        public void Exit()
        {
            _menu.Hide();
        }
    }
}