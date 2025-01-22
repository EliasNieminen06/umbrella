using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void gotomenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
}