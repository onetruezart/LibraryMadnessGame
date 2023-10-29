using Leopotam.Ecs;
using LibraryMadness.DataObjects;
using UnityEngine;

namespace LibraryMadness
{
    internal sealed class StackSystem : IEcsRunSystem, IEcsInitSystem
    {
        private StaticData _staticData;
        
        private EcsFilter<StackObjectTag>.Exclude<InStackTag> _stackObjectFilter;
        private EcsFilter<StackHolderComponent> _stackHolderFilter;

        public void Init()
        {
            foreach (var i in _stackHolderFilter)
            {
                ref var stackHolderComponent = ref _stackHolderFilter.Get1(i);
                stackHolderComponent.ObjectsInStack = new();
            }
        }
        
        public void Run()
        {
            foreach (var i in _stackObjectFilter)
            {
                ref var objEntity = ref _stackObjectFilter.GetEntity(i);
                ref var objModelComponent = ref objEntity.Get<ModelComponent>();

                Transform objTransform = objModelComponent.Transform;
                
                //TODO: Find closest stack holder
                foreach (var j in _stackHolderFilter)
                {
                    ref var stackHolderComponent = ref _stackHolderFilter.Get1(j);
                    
                    if (stackHolderComponent.ObjectsInStack.Count >= _staticData.MaxObjCountInStack)
                        continue;

                    if (Vector3.Distance(stackHolderComponent.StackRoot.position, objTransform.position) > _staticData.StackObjPickDistance) 
                        continue;

                    objEntity.Get<InStackTag>();
                    
                    ref var moveToComponent = ref objEntity.Get<MoveToComponent>();
                    moveToComponent.Root = objTransform;
                    moveToComponent.Destination = stackHolderComponent.StackRoot;
                    moveToComponent.Speed = _staticData.StackObjSpeed;
                    
                    ref var addComponent = ref objEntity.Get<AddToStackHolderComponent>();
                    addComponent.Holder = _stackHolderFilter.GetEntity(j);
                    
                    break;
                }
            }
        }
    }
}