using ShootingObjects.Entities.Components;
using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace ShootingObjects.Entities.Mono
{
    public class CubeMono : MonoBehaviour
    {
        public GameObject cube;
    }
    
    public class CubeBaker : Baker<CubeMono>
    {
        public override void Bake(CubeMono authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent(entity, new CubeProperties()
            {
                 Entity = GetEntity(authoring.cube, TransformUsageFlags.Dynamic),
                 Lives = 3,
                 RemainingTime = 1,
                 IsWaitingToRotate = false
            });
            
            AddComponent(entity, new CubeRandom()
            {
                Random = new Random((uint) UnityEngine.Random.Range(1, 100000))
            });
        }
    }
}