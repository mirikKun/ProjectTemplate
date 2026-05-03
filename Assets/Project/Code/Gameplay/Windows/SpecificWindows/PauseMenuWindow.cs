using Code.Infrastructure.Sounds;
using Code.Infrastructure.Sounds.Enum;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.SpecificWindows
{
    public class PauseMenuWindow : BaseWindow
    {
        [SerializeField] private Button _resumeButton;

        private IGameStateMachine _stateMachine;
        private ISoundsSystem _soundsSystem;

        [Inject]
        private void Construct(IGameStateMachine stateMachine, ISoundsSystem soundsSystem)
        {
            _stateMachine = stateMachine;
            _soundsSystem = soundsSystem;
        }

        protected override void Initialize()
        {
            base.Initialize();
            _resumeButton.onClick.AddListener(Resume);
            _soundsSystem.Play(DefaultSounds.WindowOpen);
        }

        protected override void UnsubscribeUpdates()
        {
            if (_resumeButton)
                _resumeButton.onClick.RemoveListener(Resume);
            base.UnsubscribeUpdates();
        }

        private void Resume()
        {
            _soundsSystem.Play(DefaultSounds.ButtonClick);
            _stateMachine.Enter<GameloopLoopState>();
        }
    }
}
