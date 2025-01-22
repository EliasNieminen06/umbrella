using Unity.VisualScripting;
using UnityEngine;

public class Hitman : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform player;
    public Transform gunEnd;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void FireProjectile()
    {
        if (player != null && projectilePrefab != null)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab, gunEnd.position, Quaternion.LookRotation(directionToPlayer));
        }
    }
}
