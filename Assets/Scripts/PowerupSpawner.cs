using System.Collections;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject powerHealth;
    public float minSpawnDistance;
    public float maxSpawnDistance;
    public float spawnCooldown;

    void Start()
    {
        StartCoroutine(Spawning());
    }

    public IEnumerator Spawning(){
        int randomObstacle = Random.Range(1,2);
        print(randomObstacle);
        if (randomObstacle == 1){
            SpawnHealth();
        }
        if (randomObstacle == 2){

        }
        if (randomObstacle == 3){

        }
        yield return new WaitForSeconds(spawnCooldown);
        StartCoroutine(Spawning());
    }

    public void SpawnHealth(){
        GameObject newHealth = Instantiate(powerHealth);
        float randomPos = Random.Range(minSpawnDistance, maxSpawnDistance);
        newHealth.transform.position = new Vector3(randomPos, transform.position.y, transform.position.z);
    }
}
