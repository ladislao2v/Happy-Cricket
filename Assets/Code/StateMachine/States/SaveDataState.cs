using Code.Services.GameDataService;
using Code.Services.SceneLoaderService;

namespace Code.StateMachine.States
{
    public class SaveDataState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IGameDataService _gameDataService;
        private readonly SceneLoader _sceneLoader;

        public SaveDataState(IStateMachine stateMachine, IGameDataService gameDataService, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _gameDataService = gameDataService;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            _gameDataService.SaveData();
            
            _sceneLoader.Restart();
            
            _stateMachine.Enter<LoadDataState>();
        }

        public void Exit() { }
    }
}