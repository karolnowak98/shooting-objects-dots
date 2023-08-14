using Unity.Entities;
using Unity.Mathematics;

namespace ShootingObjects.Entities.Components
{
    public struct EnvironmentProperties : IComponentData
    {
        public float2 FieldDimensions;
        public int NumberCubesToSpawn;
        public Entity CubePrefab;
        public Entity ProjectilePrefab;
        public float MaxRotateDelay;
        public float RespawnDelay;
    }
}