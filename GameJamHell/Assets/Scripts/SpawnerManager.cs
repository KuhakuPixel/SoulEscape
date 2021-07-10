using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public Transform[] spawnFlareCoordinates= new Transform[2];
    
    public GameObject flare;
    private List<GameObject> generatedFlares = new List<GameObject>();
    public float maxDistanceBetweenFlare;
    public const float maxAmountOfFlare = 0f;

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
        
        float xStart = spawnFlareCoordinates[0].position.x;
        float xEnd = spawnFlareCoordinates[1].position.x;
        float yStart = spawnFlareCoordinates[0].position.y;
        float yEnd = spawnFlareCoordinates[1].position.y;

        float xSpawnPosition = Random.Range(xStart, xEnd);
        float ySpawnPosition = Random.Range(yStart, yEnd);

        Vector3 playerPosition=GameObject.FindGameObjectWithTag("Player").transform.position;
        GameObject newFlare=GameObject.Instantiate(flare, new Vector3(xSpawnPosition, ySpawnPosition, 0f),flare.transform.rotation);

    }


}
