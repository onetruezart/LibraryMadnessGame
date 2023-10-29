using System;
using UnityEngine;

namespace LibraryMadness
{
    [Serializable]
    internal struct MovableComponent
    {
        public CharacterController CharacterController;
        public float Speed;
    }
}