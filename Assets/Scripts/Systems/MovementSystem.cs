using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class MovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        foreach(var (transform, speed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Speed>>())
        {
            //
        }
        float deltaTime = World.Time.DeltaTime;
        // in, verilen parametrenin referans olarak verileceğini ve fonksiyon içerisinde değiştirilemeyeceğini gösterir
        Entities.ForEach((ref LocalTransform transform, in Speed speed) =>
        {
            transform.Position += new float3(0, 0, speed.Value * deltaTime);
        }).Run();
      
    }
}
