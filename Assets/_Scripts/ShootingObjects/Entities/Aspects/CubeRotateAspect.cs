using ShootingObjects.Entities.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ShootingObjects.Entities.Aspects
{
    public readonly partial struct CubeRotateAspect : IAspect
    {
        public readonly Entity Entity;

        private readonly RefRW<LocalTransform> _transform;
        private readonly RefRW<CubeProperties> _properties;
        private readonly RefRW<CubeRandom> _cubeRandom;

        public int Lives => _properties.ValueRO.Lives;

        public void Rotate(float deltaTime)
        {
            _properties.ValueRW.RemainingTime -= deltaTime;
            
            if (_properties.ValueRO.RemainingTime > 0) return;

            _transform.ValueRW.Rotation = quaternion.Euler(0, _properties.ValueRO.RotationValue, 0);
            _properties.ValueRW.IsWaitingToRotate = false;
        }

        public bool IsWaitingToRotate => _properties.ValueRO.IsWaitingToRotate;
        public float GetRandomFloat(float min, float max) => _cubeRandom.ValueRW.Random.NextFloat(min, max);
        
        public void SetUpRotation(float remainingTime, float newRotationValue)
        {
            _properties.ValueRW.RotationValue = newRotationValue;
            _properties.ValueRW.RemainingTime = remainingTime;
            _properties.ValueRW.IsWaitingToRotate = true;
        }
    }
}