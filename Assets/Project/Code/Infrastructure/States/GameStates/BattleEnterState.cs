using Code.Gameplay;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Project.Code.Infrastructure.States.StateInfrastructure;
using Project.Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
    public class BattleEnterState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ILevelDataProvider _levelDataProvider;


        public BattleEnterState(
            IGameStateMachine stateMachine,
            ILevelDataProvider levelDataProvider)
        {
            _stateMachine = stateMachine;
            _levelDataProvider = levelDataProvider;
        }

        public void Enter()
        {
            PlaceHero();

            _stateMachine.Enter<BattleLoopState>();
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