using Unity.Entities;
using Unity.Mathematics;

namespace ShootingObjects.Entities.Components
{
    public struct EnvironmentRandom : IComponentData
    {
        public Random Random;
    }
}