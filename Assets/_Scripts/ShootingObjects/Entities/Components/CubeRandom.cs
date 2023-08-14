using Unity.Entities;
using Unity.Mathematics;

namespace ShootingObjects.Entities.Components
{
    public struct CubeRandom : IComponentData
    {
        public Random Random;
    }
}