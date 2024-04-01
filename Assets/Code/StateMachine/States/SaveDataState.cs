using Code.Services.AudioService;
using Code.Services.GameDataService;
using Code.Services.SceneLoaderService;
using DG.Tweening;

namespace Code.StateMachine.States
{
    public class SaveDataState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IGameDataService _gameDataService;
        private readonly IAudioService _audioService;
        private readonly SceneLoader _sceneLoader;

        public SaveDataState(IStateMachine stateMachine, 
            IGameDataService gameDataService, 
            IAudioService audioService, 
            SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _gameDataService = gameDataService;
            _audioService = audioService;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            _gameDataService.SaveData();
            _audioService.Clear();
            
            DOTween.Clear();
            _sceneLoader.Restart();
        }

        public void Exit() { }
    }
}