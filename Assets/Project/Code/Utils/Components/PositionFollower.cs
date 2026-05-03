using System;
using Code.Gameplay.Common.Update;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Utils.Components
{
    public class PositionFollower : MonoBehaviour, IGameUpdateable
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _transform;
        [SerializeField] private Vector3 _localOffset;
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
            _transform.position = _target.position;
            _transform.localPosition += _localOffset;
        }
    }
}