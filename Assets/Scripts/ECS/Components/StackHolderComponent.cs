using System;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace LibraryMadness
{
    [Serializable]
    internal struct StackHolderComponent
    {
        public Transform StackRoot;
        public float Offset;
        [HideInInspector] public Stack<EcsEntity> ObjectsInStack;
    }
}