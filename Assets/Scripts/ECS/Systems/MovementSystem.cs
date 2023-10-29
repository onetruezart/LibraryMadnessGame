using Leopotam.Ecs;
using UnityEngine;

namespace LibraryMadness
{
    internal sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<MovableComponent, ModelComponent, DirectionComponent> _movableFilter = null;

        public void Run()
        {
            foreach (var i in _movableFilter)
            {
                ref var movableComponent = ref _movableFilter.Get1(i);
                ref var modelComponent = ref _movableFilter.Get2(i);
                ref var directionComponent = ref _movableFilter.Get3(i);
                
                ref Vector3 dir = ref directionComponent.Direction;
                Transform transform = modelComponent.Transform;
                CharacterController characterController = movableComponent.CharacterController;
                ref float speed = ref movableComponent.Speed;

                // Vector3 entityDir = transform.right * dir.x + transform.up * dir.y + transform.forward * dir.z;
                characterController.Move(dir * speed * Time.deltaTime);
            }
        }
    }
}