using Code.Gameplay.Common.TimeService;
using Code.Gameplay.Common.UpdatesService;
using Code.Infrastructure.Input;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
    public class GameloopLoopState : IState, IUpdateable, IFixedUpdateable, ILateUpdateable
    {
        private readonly ITimeService _timeService;
        private readonly IUpdateService _updateService;
        private readonly IGameStateMachine _stateMachine;
        private readonly IInputService _inputService;

        public GameloopLoopState(
            ITimeService timeService,
            IUpdateService updateService,
            IGameStateMachine stateMachine,
            IInputService inputService)
        {
            _timeService = timeService;
            _updateService = updateService;
            _stateMachine = stateMachine;
            _inputService = inputService;
        }

        public void Enter()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _inputService.Exit += OnExitPressed;
        }

        public void Update()
        {
            _updateService.UpdateAll(_timeService.DeltaTime);
        }

        private void OnExitPressed() =>
            _stateMachine.Enter<GameplayPauseState>();

        public void FixedUpdate()
        {
            _updateService.FixedUpdateAll(_timeService.FixedDeltaTime);
        }

        public void LateUpdate()
        {
            _updateService.LateUpdateAll(_timeService.DeltaTime);
        }

        public void Exit()
        {
            _inputService.Exit -= OnExitPressed;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}