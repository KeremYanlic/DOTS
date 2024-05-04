using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct MovementSystem : ISystem
{
    public void OnCreate(ref SystemState systemState)
    {

    }

    public void OnDestroy(ref SystemState systemState)
    {

    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach(var (transform, speed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Speed>>())
        {
            //
        }
        float deltaTime = state.World.Time.DeltaTime;

        foreach(var (transform,speed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Speed>>()){
            transform.ValueRW.Position += new float3(0, 0, speed.ValueRO.Value * deltaTime);
        }

        // in, verilen parametrenin referans olarak verileceğini ve fonksiyon içerisinde değiştirilemeyeceğini gösterir
        /*Entities.ForEach((ref LocalTransform transform, in Speed speed) =>
        {
            transform.Position += new float3(0, 0, speed.Value * deltaTime);
        }).Run();*/
      
    }
}
