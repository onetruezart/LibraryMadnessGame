

using System;
using UnityEngine;

namespace LibraryMadness
{
    [Serializable]
    internal struct DirectionComponent
    {
        public float TurnSpeed;
        
        [HideInInspector] public Vector3 Direction;
    }
}