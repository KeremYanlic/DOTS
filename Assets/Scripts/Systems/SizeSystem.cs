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
        Entities.ForEach((ref LocalTransform localTransform, in Size size) =>
        {
            localTransform.Scale += size.sizeValue;
        }).Run();
    }
}
