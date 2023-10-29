
using Leopotam.Ecs;
using LibraryMadness.DataObjects;
using UnityEngine;

namespace LibraryMadness
{
    internal sealed class ObjectSpawnSystem : IEcsRunSystem
    {
        private StaticData _staticData;
        private EcsWorld _world;

        private EcsFilter<ObjectSpawnerComponent, ModelComponent>.Exclude<BlockComponent> _filter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var spanwerComponent = ref _filter.Get1(i);
                ref var modelComponent = ref _filter.Get2(i);
                
                int objId = Random.Range(0, _staticData.ObjectsPrefabs.Count);
                Vector2 randomPos = Random.insideUnitCircle * spanwerComponent.SpawnRadius;
                Vector3 spawnPos = modelComponent.Transform.position + new Vector3(randomPos.x, 0, randomPos.y);
                Quaternion randomRot = Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.up);

                GameObject spawnedObj = Object.Instantiate(_staticData.ObjectsPrefabs[objId], spawnPos, randomRot);

                var spawnedEntity = _world.NewEntity();
                spawnedEntity.Get<ModelComponent>().Transform = spawnedObj.transform;
                spawnedEntity.Get<StackObjectTag>();
                
                _filter.GetEntity(i).Get<BlockComponent>().Time = Random.Range(_staticData.GeneratorBlockTimerMin, _staticData.GeneratorBlockTimerMax);
            }
        }
    }
}