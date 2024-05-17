using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using System;

public partial class MovementSystem : SystemBase
{
    private EndSimulationEntityCommandBufferSystem endSimulationEntityCommandBufferSystem;
    

    protected override void OnCreate()
    {
        // state.WorldUnmanaged
        endSimulationEntityCommandBufferSystem = World.GetExistingSystemManaged<EndSimulationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        EntityCommandBuffer ecb = endSimulationEntityCommandBufferSystem.CreateCommandBuffer();
        
        float deltaTime =  World.Time.DeltaTime;

        // in, verilen parametrenin referans olarak verileceğini ve fonksiyon içerisinde değiştirilemeyeceğini gösterir
        Entities
            .WithAll<CapsuleTag, LocalTransform,Speed>()
            .ForEach((Entity entity,ref LocalTransform transform, in Speed speed, in CapsuleTag capsuleTag) =>
        {
            transform.Position += new float3(0, 0, speed.Value * deltaTime);

            if(transform.Position.z > 20)
            {
                //EntityManager.DestroyEntity(entity);
                ecb.DestroyEntity(entity);
            }
        }).Run();

      
    }

}
