using Code.Gameplay.Common.TimeService;
using Code.Gameplay.Common.Update;
using Code.Infrastructure.States.StateInfrastructure;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
    public class GameloopLoopState : IState, IUpdateable, IFixedUpdateable, ILateUpdateable
    {
        private readonly ITimeService _timeService;
        private readonly IUpdateService _updateService;

        public GameloopLoopState(ITimeService timeService, IUpdateService updateService)
        {
            _timeService = timeService;
            _updateService = updateService;
        }

        public void Enter()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void Update()
        {
            _updateService.UpdateAll(_timeService.DeltaTime);
        }

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
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}