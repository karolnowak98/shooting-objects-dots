using ShootingObjects.Entities.Aspects;
using ShootingObjects.Entities.Components;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace ShootingObjects.Entities.Systems
{
    [BurstCompile]
    public partial struct RotateCubesSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EnvironmentProperties>();
            state.RequireForUpdate<CubeProperties>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var time = SystemAPI.Time.DeltaTime;
            
            new CubeRotateJob
            {
                DeltaTime = time
            }.ScheduleParallel();
        }
    }

    [BurstCompile]
    public partial struct CubeRotateJob : IJobEntity
    {
        public float DeltaTime;
        
        [BurstCompile]
        private void Execute(CubeRotateAspect cube)
        {
            if (cube.IsWaitingToRotate)
            {
                cube.Rotate(DeltaTime);
            }
            
            else
            {
                cube.SetUpRotation(1, cube.GetRandomFloat(0, 360));
            }
        }
    }
}