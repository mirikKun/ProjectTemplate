using Code.Gameplay.Windows;
using Code.Infrastructure.Input;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
    public class GameplayPauseState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IWindowService _windowService;
        private readonly IInputService _inputService;

        public GameplayPauseState(
            IGameStateMachine stateMachine,
            IWindowService windowService,
            IInputService inputService)
        {
            _stateMachine = stateMachine;
            _windowService = windowService;
            _inputService = inputService;
        }

        public void Enter()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _windowService.Open(WindowId.PauseMenu);
            _inputService.Exit += OnExitPressed;
        }

        private void OnExitPressed() =>
            _stateMachine.Enter<GameloopLoopState>();

        public void Exit()
        {
            _inputService.Exit -= OnExitPressed;
            _windowService.Close(WindowId.PauseMenu);
        }
    }
}
