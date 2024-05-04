using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Jobs;
using Unity.Collections;
using Unity.Burst;

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

        DoTheJob();
    }
    protected override void OnUpdate()
    {
    }

    public void DoTheJob()
    {
        NativeArray<int> num1 = new NativeArray<int>(new int[] { 1, 3, 5, 7 }, Allocator.Persistent);
        NativeArray<int> num2 = new NativeArray<int>(new int[] { 2, 4, 6, 8 }, Allocator.Persistent);
        NativeArray<int> numSums = new NativeArray<int>(new int[] { 0, 0, 0, 0 }, Allocator.Persistent);


        var newJob = new MyJobParallel()
        {
            numbers1 = num1,
            numbers2 = num2,
            numbersSums = numSums
        };

        var handle = newJob.Schedule(num1.Length, num1.Length);
        handle.Complete();

        for (int i = 0; i < numSums.Length; i++)
        {
            Debug.Log(numSums[i]);
        }

        num1.Dispose();
        num2.Dispose();
        numSums.Dispose();
    }
}

public struct MyJob : IJob
{
    [ReadOnly]
    public NativeArray<int> numbers1;
    [ReadOnly]
    public NativeArray<int> numbers2;
    public NativeArray<int> numbersSums;

    public void Execute()
    {
        for(int i = 0; i< numbers1.Length; i++)
        {
            numbersSums[i] = numbers1[i] + numbers2[i];
        }
    }
}
[BurstCompile]
public struct MyJobParallel : IJobParallelFor
{
    [ReadOnly]
    public NativeArray<int> numbers1;
    [ReadOnly]
    public NativeArray<int> numbers2;
    public NativeArray<int> numbersSums;

    public void Execute(int index)
    {
        numbersSums[index] = numbers1[index] + numbers2[index];
    }
}