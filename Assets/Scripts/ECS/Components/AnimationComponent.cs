using System;
using UnityEngine;

namespace LibraryMadness
{
    [Serializable]
    internal struct AnimationComponent
    {
        public Animator Animator;
        public string SpeedKey;
    }
}