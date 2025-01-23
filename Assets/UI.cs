using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI fallenText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fallenText.text = "Distance Fallen " + Player.instance.fallen.ToString() + " m";
    }
}
