using Project.Code.Infrastructure.States.StateInfrastructure;
using Project.Code.Infrastructure.States.StateMachine;
using Project.Code.Progress.Data;
using Project.Code.Progress.Provider;

namespace Project.Code.Infrastructure.States.GameStates
{
    public class InitializeProgressState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IProgressProvider _progressProvider;

        public InitializeProgressState(
            IGameStateMachine stateMachine,
            IProgressProvider progressProvider)
        {
            _stateMachine = stateMachine;
            _progressProvider = progressProvider;
        }

        public void Enter()
        {
            InitializeProgress();

            _stateMachine.Enter<LoadingHomeScreenState>();
        }

        private void InitializeProgress()
        {
            CreateNewProgress();
        }

        private void CreateNewProgress()
        {
            _progressProvider.SetProgressData(new ProgressData());
        }

        public void Exit()
        {
        }
    }
}