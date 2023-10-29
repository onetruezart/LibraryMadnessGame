using Leopotam.Ecs;
using UnityEngine;

namespace LibraryMadness
{
    internal sealed class AnimationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AnimationComponent, DirectionComponent> _animationFilter = null;

        public void Run()
        {
            foreach (var i in _animationFilter)
            {
                ref var animComponent = ref _animationFilter.Get1(i);
                ref var dirComponent = ref _animationFilter.Get2(i);

                Animator animator = animComponent.Animator;
                animator.SetFloat(animComponent.SpeedKey, dirComponent.Direction.magnitude);
            }
        }
    }
}