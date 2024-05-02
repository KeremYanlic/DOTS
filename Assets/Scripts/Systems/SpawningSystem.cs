using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial class SpawningSystem : SystemBase
{
    protected override void OnStartRunning()
    {
        SpawnParameters parameters = SystemAPI.GetSingleton<SpawnParameters>();
        LocalTransform localTransform;

        for (int i = 0; i < parameters.gridWidth; i++)
        {
            for (int j = 0; j < parameters.gridHeight; j++)
            {
                // 1. yeni entity instantiate
                var newEntity = EntityManager.Instantiate(parameters.entityPrefab);

                // Bunun transform bileşeneni ayarlama
                localTransform = new LocalTransform()
                {
                    Position = new float3(i * parameters.spacing, 0, j * parameters.spacing),
                    Rotation = quaternion.identity,
                    Scale = 1f
                };
                EntityManager.SetComponentData(newEntity, localTransform);
            }
        }
    }
    protected override void OnUpdate()
    {
    }
}
