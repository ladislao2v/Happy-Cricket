using Code.StateMachine;
using Code.StateMachine.States;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Code.UI.Gameplay
{
    public class PauseView : MonoBehaviour
    {
        [SerializeField] private CustomButton _resumeButton;
        [SerializeField] private CustomButton _restartButton;
        [SerializeField] private CustomButton _homeButton;
        
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Subscribe(UnityAction action)
        {
            _resumeButton.Subscribe(action);
            _resumeButton.Subscribe(Hide);
        }

        public void Unsubscribe(UnityAction action)
        {
            _resumeButton.Unsubscribe(action);
            _resumeButton.Unsubscribe(Hide);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _restartButton.Subscribe(OnRestartClicked);
            _homeButton.Subscribe(OnHomeClicked);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _restartButton.Unsubscribe(OnRestartClicked);
            _homeButton.Unsubscribe(OnHomeClicked);
        }

        private void OnHomeClicked()
        {
            _stateMachine.Enter<SaveDataState>();
        }

        private void OnRestartClicked()
        {
            _stateMachine.Enter<PreGameState>();
        }
    }
}