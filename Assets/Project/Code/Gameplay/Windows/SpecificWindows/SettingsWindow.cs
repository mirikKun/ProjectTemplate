using Code.Infrastructure.Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows.SpecificWindows
{
    public class SettingsWindow : BaseWindow
    {
        [SerializeField] private Slider _masterVolume;
        [SerializeField] private Slider _sfxVolume;
        [SerializeField] private Slider _musicVolume;
        [SerializeField] private Slider _mouseSensitivity;

        [SerializeField] private Button _closeButton;
        private ISettingsService _settingsService;
        private IWindowService _windowService;

        [Inject]
        private void Construct(ISettingsService settingsService, IWindowService windowService)
        {
            _windowService = windowService;
            _settingsService = settingsService;
        }

        protected override void Initialize()
        {
            base.Initialize();
            _masterVolume.onValueChanged.AddListener(_settingsService.SetMasterVolume);
            _sfxVolume.onValueChanged.AddListener(_settingsService.SetSFXVolume);
            _musicVolume.onValueChanged.AddListener(_settingsService.SetMusicVolume);
            _mouseSensitivity.onValueChanged.AddListener(_settingsService.SetMouseSensitivity);

            _closeButton.onClick.AddListener(CloseWindow);

            //_settingsService.LoadSettings();

            _masterVolume.value = _settingsService.SettingsData.MasterVolume;
            _sfxVolume.value = _settingsService.SettingsData.SFXVolume;
            _musicVolume.value = _settingsService.SettingsData.MusicVolume;

            _mouseSensitivity.minValue = _settingsService.SettingsConfig.MinMouseSensitivity;
            _mouseSensitivity.maxValue = _settingsService.SettingsConfig.MaxMouseSensitivity;
            _mouseSensitivity.value = _settingsService.SettingsData.MouseSensitivity;
        }

        private void CloseWindow()
        {
            _windowService.Close(WindowId.Settings);
            _settingsService.SaveSettings();
        }
    }
}