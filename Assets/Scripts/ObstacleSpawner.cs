using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Hit Man")]
    public GameObject hitman;
    public float minHitmanDistance;
    public float maxHitmanDistance;
    [Header("Static Block")]
    public GameObject staticBlock;
    public float minStaticDistance;
    public float maxStaticDistance;
    [Header("Moving Block")]
    public GameObject MovingBlock;
    public float minMovingDistance;
    public float maxMovingDistance;

    [Header("Configuration")]
    public float spawnCooldown;

    void Start()
    {
        StartCoroutine(Spawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Spawning(){
        int randomObstacle = Random.Range(1,4);
        print(randomObstacle);
        if (randomObstacle == 1){
            SpawnHitman();
        }
        if (randomObstacle == 2){
            SpawnStatic();
        }
        if (randomObstacle == 3){
            SpawnMoving();
        }
        yield return new WaitForSeconds(spawnCooldown);
        StartCoroutine(Spawning());
    }

    public void SpawnHitman(){
        GameObject newHitman = Instantiate(hitman);
        float randomPos = Random.Range(minHitmanDistance, maxHitmanDistance);
        newHitman.transform.position = new Vector3(randomPos, transform.position.y, transform.position.z);
    }

    public void SpawnStatic(){
        GameObject newStatic = Instantiate(staticBlock);
        float randomPos = Random.Range(minStaticDistance, maxStaticDistance);
        newStatic.transform.position = new Vector3(randomPos, transform.position.y, transform.position.z);
    }

    public void SpawnMoving(){
        GameObject newMoving = Instantiate(MovingBlock);
        float randomPos = Random.Range(minMovingDistance, maxMovingDistance);
        newMoving.transform.position = new Vector3(randomPos, transform.position.y, transform.position.z);
    }
}
