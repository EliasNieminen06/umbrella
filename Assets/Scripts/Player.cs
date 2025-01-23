using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float speed;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public int fallen;
    public int health;
    public bool gameOn;
    public GameObject failScene;
    public Animator anim;

    void Awake(){
        instance = this;
    }

    void Start(){
        StartCoroutine(fallCalc());
        Announcements.instance.Announce("Get ready!", 2);
    }

    void Update(){
        if (health <= 0){
            Fail();
        }
    }

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

    public IEnumerator fallCalc(){
        while (gameOn){
            yield return new WaitForSeconds(2f);
            fallen += 1;
        }
    }

    void Fail(){
        Announcements.instance.Announce("You failed!", 10);
        failScene.SetActive(true);
        gameOn = false;
        anim.SetTrigger("fall");
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        GameObject[] hitmans = GameObject.FindGameObjectsWithTag("hitman");
        GameObject[] healths = GameObject.FindGameObjectsWithTag("health");
        foreach (GameObject obstacle in obstacles){
            Destroy(obstacle);
        }
        foreach (GameObject hitman in hitmans){
            Destroy(hitman);
        }
        foreach (GameObject healthh in healths){
            Destroy(healthh);
        }
        if (PlayerPrefs.GetInt("HighScore") < fallen){
            PlayerPrefs.SetInt("HighScore", fallen);
        }
    }

    void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("bullet")){
            health--;
        }
        if (other.gameObject.CompareTag("obstacle")){
            Fail();
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("health")){
            health++;
            Destroy(other.gameObject);
            Announcements.instance.Announce("+1 Health", 2);
        }
    }
}
