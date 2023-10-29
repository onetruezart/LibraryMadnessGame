using System.Collections.Generic;
using UnityEngine;

namespace LibraryMadness.DataObjects
{
    [CreateAssetMenu(fileName = "StaticData", menuName = "DataObjects/Create StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        [Header("CameraSettings")]
        public float SmoothTime;
        public Vector3 FollowOffset;

        [Space(50)] [Header("StackSystem")] 
        public List<GameObject> ObjectsPrefabs;
        public float StackObjSpeed;
        public float StackObjPickDistance;
        public float StackObjDropDistance;
        public float UnstackerBlockTimer;
        public float GeneratorBlockTimerMin;
        public float GeneratorBlockTimerMax;
        public float MaxObjCountInStack;
    }
}