using System;
using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using LibraryMadness.DataObjects;
using UnityEngine;
using Voody.UniLeo;

namespace LibraryMadness
{
    public class EcsInit : MonoBehaviour
    {
        [SerializeField] private StaticData _staticData;
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private UISceneData _uiSceneData;
        
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.ConvertScene();
            
            AddInjections();
            AddSystems();
            //AddOneFrames();
            
            _systems.Init();
        }

        private void AddInjections()
        {
            _systems
                .Inject(_sceneData)
                .Inject(_staticData)
                .Inject(_uiSceneData);
        }

        private void AddSystems()
        {
            _systems
                .Add(new BlockSystem())
                .Add(new InputSystem())
                .Add(new RotateToDirectionSystem())
                .Add(new MovementSystem())
                .Add(new MoveToSystem())
                .Add(new StackSystem())
                .Add(new AddToStackHolderSystem())
                .Add(new UnstackSystem())
                .Add(new DropStackObjectSystem())
                .Add(new AnimationSystem())
                .Add(new ObjectSpawnSystem())
                .Add(new MoveMainCameraSystem())
                .Add(new UISystem());
        }

        // private void AddOneFrames()
        // {
        //
        // }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            if (_systems == null)
                return;
            
            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }

}
