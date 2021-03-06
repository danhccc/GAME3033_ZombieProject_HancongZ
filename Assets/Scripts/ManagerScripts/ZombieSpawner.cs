using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public int numberOfZombiesToSpawn;
    public GameObject[] zombiePrefabs;
    public SpawnerVolume[] spawnVolumes;
    GameObject followGameObject;

    // Start is called before the first frame update
    void Start()
    {
        

        for (int i = 0; i < numberOfZombiesToSpawn; i++)
        {
            SpawnZombie();
        }
    }

    void SpawnZombie()
    {
        GameObject zombieToSpawn = zombiePrefabs[Random.Range(0, zombiePrefabs.Length)];
        SpawnerVolume spawnVolume = spawnVolumes[Random.Range(0, spawnVolumes.Length)];

        //if (!followGameObject) return;

        // Object pooling can be reference here
        GameObject zombie = Instantiate(zombieToSpawn, spawnVolume.GetPositionInBounds(), spawnVolume.transform.rotation);

        //zombie.GetComponent<ZombieComponent>().Initialize(followGameObject);
    }
}
