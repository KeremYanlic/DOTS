using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
public class SpawnParametersAuthoring : MonoBehaviour
{
    public GameObject entityPrefab;
    public int gridWidth;
    public int gridHeight;
    public float spacing; 
}
public partial class SpawnParamsBaker : Baker<SpawnParametersAuthoring>
{
    public override void Bake(SpawnParametersAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);

        AddComponent(entity, new SpawnParameters()
        {
            entityPrefab = GetEntity(authoring.entityPrefab, TransformUsageFlags.Dynamic),
            gridWidth = authoring.gridWidth,
            gridHeight = authoring.gridHeight,
            spacing = authoring.spacing
        });
    }
}
