using Leopotam.Ecs;
using UnityEngine;

namespace LibraryMadness
{
    internal sealed class DropStackObjectSystem : IEcsRunSystem
    {
        private EcsFilter<DropComponent>.Exclude<MoveToComponent> _filter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var dropComponent = ref _filter.Get1(i);
                ref var objEntity = ref _filter.GetEntity(i);
                ref var modelComponent = ref objEntity.Get<ModelComponent>();
                ref var unstackerComponent = ref dropComponent.Dropper.Get<UnstackerComponent>();

                unstackerComponent.CountOfObjects += 1;
                
                Object.Destroy(modelComponent.Transform.gameObject);
                objEntity.Destroy();
            }
        }
    }
}