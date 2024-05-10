using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class MovementSystem : SystemBase
{
   
    protected override void OnUpdate()
    {
        float deltaTime =  World.Time.DeltaTime;

        // in, verilen parametrenin referans olarak verileceğini ve fonksiyon içerisinde değiştirilemeyeceğini gösterir
        Entities
            .WithAll<CapsuleTag, LocalTransform,Speed>()
            .ForEach((ref LocalTransform transform, in Speed speed, in CapsuleTag capsuleTag) =>
        {
            transform.Position += new float3(0, 0, speed.Value * deltaTime);
        }).Schedule();
      
    }

}
