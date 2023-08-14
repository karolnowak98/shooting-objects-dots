using ShootingObjects.Entities.Components;
using ShootingObjects.Game.Logic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace ShootingObjects.Entities.Mono
{
    public class EnvironmentMono : MonoBehaviour
    {
        public uint RandomSeed;
        public float2 FieldDimensions;
        public GameObject CubePrefab;
        public GameObject ProjectilePrefab;
        public float MaxRotateDelay;
        public float RespawnDelay;
    }

    public class EnvironmentBaker : Baker<EnvironmentMono>
    {
        public override void Bake(EnvironmentMono authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent(entity, new EnvironmentProperties
            {
                FieldDimensions = authoring.FieldDimensions,
                NumberCubesToSpawn = GameManager.NumberOfCubesToSpawn,
                CubePrefab = GetEntity(authoring.CubePrefab, TransformUsageFlags.Dynamic),
                ProjectilePrefab = GetEntity(authoring.ProjectilePrefab, TransformUsageFlags.Dynamic), 
                MaxRotateDelay = authoring.MaxRotateDelay,
                RespawnDelay = authoring.RespawnDelay
            });
            
            AddComponent(entity, new EnvironmentRandom
            {
                Random = Random.CreateFromIndex(authoring.RandomSeed)
            });
        }
    }
}