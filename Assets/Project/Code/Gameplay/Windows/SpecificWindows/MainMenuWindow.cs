using Code.Gameplay.Levels.Enum;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.SpecificWindows
{
    public class MainMenuWindow:BaseWindow
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;
        private IGameStateMachine _stateMachine;
        private IWindowService _windowService;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine,IWindowService windowService)
        {
            _windowService = windowService;
            _stateMachine = gameStateMachine;
        }
        protected override void Initialize()
        {
            base.Initialize();
            _playButton.onClick.AddListener(LoadGameplayScene);
            _settingsButton.onClick.AddListener(OpenSettingsWindow);
            _exitButton.onClick.AddListener(Exit);
#if UNITY_WEBGL
            _exitButton.gameObject.SetActive(false);
#endif
            
        }

        private void LoadGameplayScene()
        {
            _stateMachine.Enter<LoadingGameplayState,Scenes>(Scenes.Gameplay);
        }

        private void OpenSettingsWindow()
        {
            _windowService.Open(WindowId.Settings);
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}