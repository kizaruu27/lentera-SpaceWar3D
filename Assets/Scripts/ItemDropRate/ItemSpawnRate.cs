using System;
using UnityEngine;

[Serializable]
public class ItemSpawnRate
{
    [Range(0, 100)] public int itemRate;
    public GameObject itemPrefab;
}
