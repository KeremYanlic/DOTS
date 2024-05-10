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
    public event EventHandler OnPassedZ20;

    public struct OnPassedZ20Type
    {
         
    }

    private NativeQueue<OnPassedZ20Type> eventQueue;

    protected override void OnCreate()
    {
        eventQueue = new NativeQueue<OnPassedZ20Type>(Allocator.Persistent);

        OnPassedZ20 += MovementSystem_OnPassedZ20;
    }

    
    protected override void OnDestroy()
    {
        eventQueue.Dispose();
    }
    private void MovementSystem_OnPassedZ20(object sender, EventArgs e)
    {
        Debug.Log("Heyy");
    }

    protected override void OnUpdate()
    { 
        float deltaTime =  World.Time.DeltaTime;

        NativeQueue<OnPassedZ20Type>.ParallelWriter eventQueueParallel = eventQueue.AsParallelWriter();

        // in, verilen parametrenin referans olarak verileceğini ve fonksiyon içerisinde değiştirilemeyeceğini gösterir
        Entities
            .WithAll<CapsuleTag, LocalTransform,Speed>()
            .ForEach((ref LocalTransform transform, in Speed speed, in CapsuleTag capsuleTag) =>
        {
            transform.Position += new float3(0, 0, speed.Value * deltaTime);

            if(transform.Position.z > 20)
            {
                eventQueueParallel.Enqueue(new OnPassedZ20Type()
                {

                });
            }
        }).Run();

        while(eventQueue.TryDequeue(out OnPassedZ20Type onPassedZ20Type))
        {
            OnPassedZ20?.Invoke(null, null);
        }
    }

}
