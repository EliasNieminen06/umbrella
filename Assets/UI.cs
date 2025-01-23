using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class UI : MonoBehaviour
{
    public static UI instance;
    public TextMeshProUGUI fallenText;
    public GameObject healthPf;
    public GameObject healthParent;

    void Awake(){
        instance = this;
    }

    void Start()
    {
        for (int i=0; i < Player.instance.health; i++){
            AddHealth();
        }
    }

    // Update is called once per frame
    void Update()
    {
        fallenText.text = "Distance Fallen " + Player.instance.fallen.ToString() + " m";
    }
    
    public void AddHealth(){
        GameObject newHealthObj = Instantiate(healthPf, transform.parent = healthParent.transform);
    }

    public void RemoveHealth(){
        Destroy(GameObject.FindGameObjectWithTag("healthUI"));
    }
}
