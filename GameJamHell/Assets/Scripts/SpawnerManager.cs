using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public Transform[] spawnFlareCoordinates = new Transform[2];

    public GameObject flare;
    private List<GameObject> generatedFlares = new List<GameObject>();
    public float minDistanceBetweenFlare;
    public float maxAmountOfFlare = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        if (spawnFlareCoordinates.Length != 2)
        {
            throw new System.ArgumentException("spawnFlareCoordinates's length must be exactly 2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnFlareRandomly();
        }
    }

    void SpawnFlareRandomly()
    {

       
        Vector2 spawnPosition = GetFlareSpawnCoordinate();

    
        GameObject newFlare = GameObject.Instantiate(flare, new Vector3(spawnPosition.x, spawnPosition.y, 0f), flare.transform.rotation);
        generatedFlares.Add(newFlare);
        if (generatedFlares.Count >= maxAmountOfFlare + 1)
        {
            //destroy
            Destroy(generatedFlares[0]);
            generatedFlares.RemoveAt(0);

        }



    }

    Vector2 GetFlareSpawnCoordinate()
    {
        float xStart = spawnFlareCoordinates[0].position.x;
        float xEnd = spawnFlareCoordinates[1].position.x;
        float yStart = spawnFlareCoordinates[0].position.y;
        float yEnd = spawnFlareCoordinates[1].position.y;

        float xSpawnPosition = Random.Range(xStart, xEnd);
        float ySpawnPosition = Random.Range(yStart, yEnd);
        Vector2 SpawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);

        bool spawnPositionIsValid = IsFlareSpawnPositionValid(SpawnPosition);
        while (!spawnPositionIsValid)
        {
            xSpawnPosition = Random.Range(xStart, xEnd);
            ySpawnPosition = Random.Range(yStart, yEnd);
            SpawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
            spawnPositionIsValid = IsFlareSpawnPositionValid(SpawnPosition);

        }
        return SpawnPosition;
    }

    /// <summary>
    /// Check for nearby flares
    /// </summary>
    /// <returns></returns>
    bool IsFlareSpawnPositionValid(Vector2 spawnPosition)
    {
        for (int i = 0; i < generatedFlares.Count; i++)
        {
            float distanceBetweenFlares = Vector2.Distance(generatedFlares[i].transform.position, spawnPosition);

            if (distanceBetweenFlares < minDistanceBetweenFlare)
            {
                return false;
            }
        }
        return true;
    }
}
