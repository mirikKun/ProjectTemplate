using System;
using Code.Gameplay.Windows;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Levels.MainMenu
{
    public class MainMenuInitializer:MonoBehaviour
    {
        private IWindowService _windowService;

        [Inject]
        private void Construct(IWindowService windowService)
        {
            _windowService = windowService;
        }

        private void Start()
        {
            _windowService.Open(WindowId.MainMenu);
        }
    }
}