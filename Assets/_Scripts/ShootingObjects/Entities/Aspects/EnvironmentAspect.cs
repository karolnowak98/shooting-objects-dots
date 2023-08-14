using ShootingObjects.Entities.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ShootingObjects.Entities.Aspects
{
    public readonly partial struct EnvironmentAspect : IAspect
    {
        public readonly Entity Entity;
        
        private readonly RefRO<LocalTransform> _transform;
        private readonly RefRO<EnvironmentProperties> _environmentProperties;
        private readonly RefRW<EnvironmentRandom> _environmentRandom;
        
        public int NumberCubesToSpawn => _environmentProperties.ValueRO.NumberCubesToSpawn;
        public Entity CubePrefab => _environmentProperties.ValueRO.CubePrefab;

        public LocalTransform GetRandomCubeTransform()
        {
            return new LocalTransform
            {
                Position = GetRandomPosition(),
                Rotation = GetRandomRotation(),
                Scale = 1
            };
        }

        private LocalTransform Transform => _transform.ValueRO;
        
        private float3 GetRandomPosition()
        {
            var randomPosition = _environmentRandom.ValueRW.Random.NextFloat3(MinCorner, MaxCorner);
            return randomPosition;
        }

        private quaternion GetRandomRotation() => quaternion.RotateY(_environmentRandom.ValueRW.Random.NextFloat(-0.25f, 0.25f));
        
        private float3 MinCorner => Transform.Position - HalfDimensions;
        private float3 MaxCorner => Transform.Position + HalfDimensions;

        private float3 HalfDimensions => new()
        {
            x = _environmentProperties.ValueRO.FieldDimensions.x * 0.5f,
            y = 0f,
            z = _environmentProperties.ValueRO.FieldDimensions.y * 0.5f
        };
    }
}