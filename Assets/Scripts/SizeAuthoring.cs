using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SizeAuthoring : MonoBehaviour
{
    public float sizeValue;
  
}
public class SizeBaker : Baker<SizeAuthoring>
{
    public override void Bake(SizeAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);

        AddComponent(entity, new Size
        {
            sizeValue = authoring.sizeValue
        });
    }
}

