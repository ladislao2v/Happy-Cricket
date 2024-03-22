using Code.UI.ClubCreation;
using UnityEngine;

namespace Code.StateMachine.States
{
    public class ClubCreateState : IState
    {
        private readonly ClubCreationOverlay _creationOverlay;

        public ClubCreateState(ClubCreationOverlay creationOverlay)
        {
            _creationOverlay = creationOverlay;
        }
        public void Enter()
        {
            _creationOverlay.Show();
        }

        public void Exit()
        {
            _creationOverlay.Hide();
        }
    }
}