using Unity.VisualScripting;
using UnityEngine;

public class MoveObstaclesUp : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    void Start(){
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }
}
