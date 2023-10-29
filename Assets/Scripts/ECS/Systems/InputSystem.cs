using Leopotam.Ecs;
using LibraryMadness.DataObjects;
using UnityEngine;

namespace LibraryMadness
{
    internal sealed class InputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionComponent> _directionFilter = null;
        private SceneData _sceneData;

        private Vector3 _dir;

        public void Run()
        {
            SetDirection();
            
            foreach (var i in _directionFilter)
            {
                ref var dirComponent = ref _directionFilter.Get2(i);
                ref Vector3 direction = ref dirComponent.Direction;
                ref float turnSpeed = ref dirComponent.TurnSpeed;

                if (_dir == Vector3.zero)
                {
                    direction = Vector3.zero;
                }
                else
                {
                    Vector3 dir = Vector3.Slerp(direction, _dir, turnSpeed * Time.deltaTime);
                    dir.y = 0;
                    dir = dir.normalized;
                    direction = dir;
                }
                    
            }
        }

        private void SetDirection()
        {
            //TODO: Make custom input system 
            float xDir = Mathf.Clamp(Input.GetAxisRaw("Horizontal") + _sceneData.Joystick.Horizontal, -1, 1);
            float zDir =  Mathf.Clamp(Input.GetAxisRaw("Vertical") + _sceneData.Joystick.Vertical, -1, 1);

            if (Camera.main != null)
            {
                Transform transform = _sceneData.MainCamera.transform;
                    
               _dir = xDir * transform.right + zDir * transform.up;
               _dir.y = 0;
               _dir = _dir.normalized;
            }
            else
            {
                _dir = new Vector3(xDir, 0, zDir);
            }
        }
    }
}