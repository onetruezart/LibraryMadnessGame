using Leopotam.Ecs;
using LibraryMadness.DataObjects;
using UnityEngine;

namespace LibraryMadness
{
    public sealed class MoveMainCameraSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerTag, ModelComponent> _playerFilter = null;
        private StaticData _staticData;
        private SceneData _sceneData;

        private Vector3 _currentVelocity; 

        public void Run()
        {
            foreach (var i in _playerFilter)
            {
                ref var modelComponent = ref _playerFilter.Get2(i);

                Transform playerTransform = modelComponent.Transform;
            
                var currentPos = _sceneData.MainCamera.transform.position;
                currentPos = Vector3.SmoothDamp(currentPos, playerTransform.position + _staticData.FollowOffset, ref _currentVelocity, _staticData.SmoothTime);
                _sceneData.MainCamera.transform.position = currentPos;
            }
        }
    }
}