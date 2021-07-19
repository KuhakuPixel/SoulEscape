using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PickableItemSpawnProperty 
{

    
    public  int maxSpawnCount=0;
    public  float minDistanceBetweenItem = 0f;
    
    public GameObject itemPrefab;
    [HideInInspector] public  List<GameObject> spawnedItems;
    
    public float GetItemColliderRadius()
    {
        return itemPrefab.GetComponent<CircleCollider2D>().radius;
    }
    
}
