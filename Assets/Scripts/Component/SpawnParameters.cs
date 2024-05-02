using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct SpawnParameters : IComponentData
{
    public Entity entityPrefab;
    public int gridWidth;
    public int gridHeight;
    public float spacing;
  
}
