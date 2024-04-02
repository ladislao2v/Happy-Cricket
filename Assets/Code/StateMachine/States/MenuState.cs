using Code.Services.ScoreService;
using Code.Services.SkinService;
using Code.UI.Menu;

namespace Code.StateMachine.States
{
    public class MenuState : IState
    {
        private readonly MenuOverlay _menu;
        private readonly ISkinService _skinService;
        private readonly IScoreService _scoreService;

        public MenuState(MenuOverlay menu, ISkinService skinService, IScoreService scoreService)
        {
            _menu = menu;
            _skinService = skinService;
            _scoreService = scoreService;
        }
        
        public void Enter()
        {
            _menu.Show();
            
            
            if(_skinService.LastSkin > -1)
                _skinService.Dress();
        }

        public void Exit()
        {
            _menu.Hide();
            _scoreService.Reset();
        }
    }
}