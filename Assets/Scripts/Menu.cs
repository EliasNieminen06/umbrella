using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI hs;
    void Start(){
        if (hs != null){
            hs.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    public void play()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void gotomenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ResetHS(){
        PlayerPrefs.SetInt("HighScore", 0);
        if (hs != null){
            hs.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
}