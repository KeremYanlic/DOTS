using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class SizeSystem : SystemBase
{
    
    protected override void OnUpdate()
    {
        
        float deltaTime = World.Time.DeltaTime;
        
        Entities.
            WithAll<LocalTransform, Size, CapsuleTag>().
            ForEach((ref LocalTransform localTransform, in Size size,in CapsuleTag capsuleTag) =>
        {
            localTransform.Scale += size.sizeValue * deltaTime;
        }).Run();
    }
}
