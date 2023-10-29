using Leopotam.Ecs;
using LibraryMadness.DataObjects;
using UnityEngine;

namespace LibraryMadness
{
    internal class UISystem : IEcsRunSystem
    {
        private UISceneData _uiSceneData;
        private StaticData _staticData;
        
        private EcsFilter<UnstackerComponent> _unstackerFilter = null;
        private EcsFilter<StackHolderComponent> _stackerFilter = null;

        public void Run()
        {
            int count = 0;
            
            foreach (var i in _stackerFilter)
            {
                ref var stackerComponent = ref _stackerFilter.Get1(i);
                count += stackerComponent.ObjectsInStack.Count;
            }

            _uiSceneData.YoursBooksText.text = $"У тебя книг - {count} из {_staticData.MaxObjCountInStack}";
            
            count = 0;
            
            foreach (var i in _unstackerFilter)
            {
                ref var unstackerComponent = ref _unstackerFilter.Get1(i);
                count += unstackerComponent.CountOfObjects;
            }

            _uiSceneData.InBoxBooksText.text = $"В коробке книг - {count}";
        }
        
    }
}