using System;
using Leopotam.Ecs;
using UnityEngine;

namespace LibraryMadness
{
    internal struct MoveToComponent
    {
        public Transform Destination;
        public Transform Root;
        public float Speed;
    }
}