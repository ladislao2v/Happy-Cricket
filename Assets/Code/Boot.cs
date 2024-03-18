using System;
using Code.StateMachine;
using Code.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Code
{
    public class Boot : MonoBehaviour
    {
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Awake()
        {
            _stateMachine.Enter<InitialState>();
        }
    }
}
