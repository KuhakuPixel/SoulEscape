using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
  
    
    public Transform[] spawnItemCoordinatesRange = new Transform[2];

  
    public PickableItemSpawnProperty flareSpawnProperty;
    public PickableItemSpawnProperty paperSpawnProperty;
    public static  SpawnerManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (spawnItemCoordinatesRange.Length != 2)
        {
            throw new System.ArgumentException("spawnFlareCoordinates's length must be exactly 2");
        }
        instance = this;
    }

    private void Start()
    {
        //spawn paper
        for(int i = 0; i < paperSpawnProperty.maxSpawnCount; i++)
        {
           SpawnItemRandomly(paperSpawnProperty);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        //making sure there will be x number of flare always

        while (flareSpawnProperty.spawnedItems.Count<flareSpawnProperty.maxSpawnCount)
        {
            SpawnItemRandomly(flareSpawnProperty);
        }
       
    }

    public void SpawnItemRandomly(PickableItemSpawnProperty itemToSpawnProperty)
    {

       
        Vector2 spawnPosition = GetRandomItemSpawnCoordinate(itemToSpawnProperty);

    
        GameObject newItem = GameObject.Instantiate(itemToSpawnProperty.itemPrefab, new Vector3(spawnPosition.x, spawnPosition.y, 0f), itemToSpawnProperty.itemPrefab.transform.rotation);
        newItem.GetComponent<PickableItemScript>().InitializeItemProperty(itemToSpawnProperty);
        itemToSpawnProperty.spawnedItems.Add(newItem);
        Debug.Log("Sucsessfully spawned: " + itemToSpawnProperty.itemPrefab.name +" at: "+spawnPosition);
       



    }

    Vector2 GetRandomItemSpawnCoordinate(PickableItemSpawnProperty itemToSpawnProperty)
    {
        float xStart = spawnItemCoordinatesRange[0].position.x;
        float xEnd = spawnItemCoordinatesRange[1].position.x;
        float yStart = spawnItemCoordinatesRange[0].position.y;
        float yEnd = spawnItemCoordinatesRange[1].position.y;

        float xSpawnPosition = Random.Range(xStart, xEnd);
        float ySpawnPosition = Random.Range(yStart, yEnd);
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);

        bool spawnPositionIsValid = IsSpawnPositionValid(itemToSpawnProperty,spawnPosition);
        while (!spawnPositionIsValid)
        {
            Debug.Log("Spawn position is is not valid while trying to spawn: " + itemToSpawnProperty.itemPrefab.name + " at :" + spawnPosition);
            xSpawnPosition = Random.Range(xStart, xEnd);
            ySpawnPosition = Random.Range(yStart, yEnd);
            spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
            spawnPositionIsValid = IsSpawnPositionValid(itemToSpawnProperty,spawnPosition);

        }
        return spawnPosition;
    }

    /// <summary>
    /// Check for nearby flares
    /// </summary>
    /// <returns></returns>
    bool IsSpawnPositionValid(PickableItemSpawnProperty itemToSpawnProperty, Vector2 spawnPosition)
    {
        for (int i = 0; i < itemToSpawnProperty.spawnedItems.Count; i++)
        {
            float distanceBetweenItem = Vector2.Distance(itemToSpawnProperty.spawnedItems[i].transform.position, spawnPosition);

            if (distanceBetweenItem < itemToSpawnProperty.minDistanceBetweenItem)
            {
                return false;
            }
        }
        //spawn phyiscs 2d collider to check if there is nearby collider
        Collider2D[] nearbyColliders=Physics2D.OverlapCircleAll(spawnPosition, itemToSpawnProperty.GetItemColliderRadius());
        if (nearbyColliders.Length > 0)
        {
            return false;
        }
        return true;
    }
}
