using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A)){
            if(transform.position.x > minX){
                transform.Translate(-transform.right * speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.D)){
            if(transform.position.x < maxX){
                transform.Translate(transform.right * speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.S)){
            if(transform.position.y > minY){
                transform.Translate(-transform.up * speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.W)){
            if(transform.position.y < maxY){
                transform.Translate(transform.up * speed * Time.deltaTime);
            }
        }
    }
}
