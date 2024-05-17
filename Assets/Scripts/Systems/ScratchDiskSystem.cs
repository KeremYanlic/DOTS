using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public partial class ScratchDiskSystem : SystemBase
{
    private Entity scratchDiskSystemEntity;

    protected override void OnCreate()
    {
        scratchDiskSystemEntity = EntityManager.CreateEntity();

        EntityManager.AddComponent<ScratchDiskSytemTag>(scratchDiskSystemEntity);
        EntityManager.AddComponent<DeinitializeComponent>(scratchDiskSystemEntity);
    }
    protected override void OnUpdate()
    {
       /* Entities.
             WithNone<ScratchDiskSytemTag>().
             ForEach(
            (in DeinitializeComponent deinit) =>
            {
                Debug.Log("Deleting scratch disk file ");
            }).Run(); */
    }
}
