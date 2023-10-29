using Leopotam.Ecs;
using UnityEngine;

namespace LibraryMadness
{
    internal sealed class BlockSystem : IEcsRunSystem 
    {
        private EcsFilter<BlockComponent> _filter = null;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var blockComponent = ref _filter.Get1(i);

                blockComponent.Time -= Time.deltaTime;

                if (blockComponent.Time <= 0)
                    _filter.GetEntity(i).Del<BlockComponent>();
            }
        }
    }
}