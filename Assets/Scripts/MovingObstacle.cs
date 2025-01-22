using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float minMovingDistance;
    public float maxMovingDistance;
    public float speed;

    private float destination;
    private bool isGoingLeft;

    void Start()
    {
        destination = minMovingDistance;
        isGoingLeft = Random.Range(0, 2) == 0;
    }

    void Update()
    {
        if (isGoingLeft && transform.position.x <= minMovingDistance)
        {
            destination = maxMovingDistance;
            isGoingLeft = false;
        }
        else if (!isGoingLeft && transform.position.x >= maxMovingDistance)
        {
            destination = minMovingDistance;
            isGoingLeft = true;
        }
    }

    void FixedUpdate()
    {
        if (isGoingLeft)
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
    }
}
