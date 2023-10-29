using Leopotam.Ecs;
using LibraryMadness.DataObjects;
using UnityEngine;

namespace LibraryMadness
{
    internal sealed class UnstackSystem : IEcsRunSystem
    {
        private StaticData _staticData;
        
        private EcsFilter<UnstackerComponent>.Exclude<BlockComponent> _unstackerFilter = null;
        private EcsFilter<StackHolderComponent> _stackerFilter = null;

        public void Run()
        {
            foreach (var i in _unstackerFilter)
            {
                ref var unstackerEntity = ref _unstackerFilter.GetEntity(i);
                ref var unstackerComponent = ref _unstackerFilter.Get1(i);

                Transform unstackerTransform = unstackerComponent.Root;

                bool findObj = false;
                
                //TODO: Find closest stack holder
                foreach (var j in _stackerFilter)
                {
                    ref var stackHolderComponent = ref _stackerFilter.Get1(j);

                    if (Vector3.Distance(stackHolderComponent.StackRoot.position, unstackerTransform.position) > _staticData.StackObjDropDistance) 
                        continue;

                    if (!stackHolderComponent.ObjectsInStack.TryPop(out EcsEntity objEntity)) 
                        continue;

                    ref var moveToComponent = ref objEntity.Get<MoveToComponent>();
                    moveToComponent.Root = objEntity.Get<ModelComponent>().Transform;
                    moveToComponent.Destination = unstackerTransform;
                    moveToComponent.Speed = _staticData.StackObjSpeed;

                    moveToComponent.Root.parent = null;

                    ref var dropComponent = ref objEntity.Get<DropComponent>();
                    dropComponent.Dropper = unstackerEntity;

                    findObj = true;

                    break;
                }

                if (findObj)
                    unstackerEntity.Get<BlockComponent>().Time = _staticData.UnstackerBlockTimer;

            }
        }
    }
}