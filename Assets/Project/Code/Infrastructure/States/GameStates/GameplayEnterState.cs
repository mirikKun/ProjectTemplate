using Code.Gameplay.Levels;
using Project.Code.Infrastructure.States.StateInfrastructure;
using Project.Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
    public class GameplayEnterState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ILevelDataProvider _levelDataProvider;


        public GameplayEnterState(
            IGameStateMachine stateMachine,
            ILevelDataProvider levelDataProvider)
        {
            _stateMachine = stateMachine;
            _levelDataProvider = levelDataProvider;
        }

        public void Enter()
        {
            PlaceHero();

            _stateMachine.Enter<GameloopLoopState>();
        }

        private void PlaceHero()
        {
            _heroFactory.CreateHero(_levelDataProvider.StartPoint);
        }

        public void Exit()
        {
        }
    }
}