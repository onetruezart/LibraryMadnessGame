using Leopotam.Ecs;
using UnityEngine;

namespace LibraryMadness
{
    internal sealed class MoveToSystem : IEcsRunSystem
    {
        private const float FinishDistance = 0.4f;
        
        private readonly EcsFilter<MoveToComponent> _filter = null;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var moveToComponent = ref _filter.Get1(i);

                if (Vector3.Distance(moveToComponent.Destination.position, moveToComponent.Root.position) < FinishDistance)
                {
                    _filter.GetEntity(i).Del<MoveToComponent>();
                    continue;
                }

                moveToComponent.Root.position = Vector3.MoveTowards(moveToComponent.Root.position,
                    moveToComponent.Destination.position, moveToComponent.Speed * Time.deltaTime);
            }
        }
    }
}