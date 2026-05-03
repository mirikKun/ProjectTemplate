using System;
using Code.Gameplay.Common.Update;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Utils.Components
{
    public class Rotator:MonoBehaviour,IGameUpdateable
    {
        [SerializeField] private Vector3 _axis;
        [SerializeField] private float _speed;
        private IUpdateService _updateService;

        [Inject]
        private void Construct(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        private void Start()
        {
            _updateService.Update.Register(this);
        }
        private void OnDestroy()
        {
            _updateService.Update.Unregister(this);
        }

        public void GameUpdate(float deltaTime)
        {
            transform.Rotate(_axis,_speed*deltaTime);
        }
    }
}