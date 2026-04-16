using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Configs;
using Code.Infrastructure.Settings.Configs;
using Code.Infrastructure.Sounds.ScriptableObjects;
using UnityEngine;

namespace Code.Infrastructure.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private SettingsConfig _settingsConfig;
        private SoundMixersSO _soundMixersSo;

        private Dictionary<WindowId, GameObject> _windowPrefabsById;

        public void LoadAll()
        {
            LoadWindows();
            LoadSettingsConfig();
            LoadMixersData();

        }

        private void LoadMixersData()
        {
            _soundMixersSo  = Resources
                .Load<SoundMixersSO>("Configs/Sound/SoundMixersConfig");        }


        public GameObject GetWindowPrefab(WindowId id) =>
            _windowPrefabsById.TryGetValue(id, out GameObject prefab)
                ? prefab
                : throw new Exception($"Prefab config for window {id} was not found");

        private void LoadWindows()
        {
            _windowPrefabsById = Resources
                .Load<WindowsConfig>("Configs/WindowConfig")
                .WindowConfigs
                .ToDictionary(x => x.Id, x => x.Prefab);
        }
        
        public SettingsConfig GetSettingsConfig() => 
            _settingsConfig ?? throw new Exception("Settings config was not loaded");
        public SoundMixersSO GetSoundMixersSO()=>_soundMixersSo;

        private void LoadSettingsConfig()
        {
            _settingsConfig  = Resources
                .Load<SettingsConfig>("Configs/SettingsConfig");
        }

    }
}