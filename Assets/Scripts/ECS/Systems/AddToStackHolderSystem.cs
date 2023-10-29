using Leopotam.Ecs;
using UnityEngine;

namespace LibraryMadness
{
    internal sealed class AddToStackHolderSystem : IEcsRunSystem
    {
        private EcsFilter<AddToStackHolderComponent>.Exclude<MoveToComponent> _filter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var addToStackComponent = ref _filter.Get1(i);
                ref var objEntity = ref _filter.GetEntity(i);
                ref var modelComponent = ref objEntity.Get<ModelComponent>();
                ref var stackComponent = ref addToStackComponent.Holder.Get<StackHolderComponent>();

                modelComponent.Transform.parent = stackComponent.StackRoot;
                stackComponent.ObjectsInStack.Push(objEntity);

                modelComponent.Transform.localEulerAngles = Vector3.zero;
                modelComponent.Transform.localPosition = new Vector3(0, stackComponent.Offset * (stackComponent.ObjectsInStack.Count - 1), 0);
                
                objEntity.Del<AddToStackHolderComponent>();
            }
        }
    }
}