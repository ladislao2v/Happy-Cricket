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
            _homeButton.Subscribe(OnHomeClicked);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _homeButton.Unsubscribe(OnHomeClicked);
        }

        private void OnHomeClicked()
        {
            Time.timeScale = 1;
            _stateMachine.Enter<SaveDataState>();
        }
    }
}