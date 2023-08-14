using Unity.Entities;

namespace ShootingObjects.Entities.Components
{
    public struct CubeProperties : IComponentData
    {
        public Entity Entity;
        public int Lives;
        public float RemainingTime;
        public bool IsWaitingToRotate;
        public float RotationValue;
    }
}