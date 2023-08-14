using ShootingObjects.Entities.Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using EnvironmentAspect = ShootingObjects.Entities.Aspects.EnvironmentAspect;

namespace ShootingObjects.Entities.Systems
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct SpawnCubesSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EnvironmentProperties>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;
            var environmentEntity = SystemAPI.GetSingletonEntity<EnvironmentProperties>();
            var environment = SystemAPI.GetAspect<EnvironmentAspect>(environmentEntity);
            
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            
            for (var i = 0; i < environment.NumberCubesToSpawn; i++)
            {
                var newCube = ecb.Instantiate(environment.CubePrefab);
                var newCubeTransform = environment.GetRandomCubeTransform();
                ecb.SetComponent(newCube, newCubeTransform);
            }

            ecb.Playback(state.EntityManager);
        }
    }
}