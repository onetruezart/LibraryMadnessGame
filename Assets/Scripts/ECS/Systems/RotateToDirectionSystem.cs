using Leopotam.Ecs;
using UnityEngine;

namespace LibraryMadness
{
    internal sealed class RotateToDirectionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ModelComponent, DirectionComponent> _rotateToDirfilter = null;

        public void Run()
        {
            foreach (var i in _rotateToDirfilter)
            {
                ref var modelComponent = ref _rotateToDirfilter.Get1(i);
                ref var dirComponent = ref _rotateToDirfilter.Get2(i);

                Transform transform = modelComponent.Transform;
                
                ref Vector3 direction = ref dirComponent.Direction;

                if (direction != Vector3.zero)
                    transform.forward = direction;
            }
        }
    }
}