
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("TestingNewAnim");
    }

    public void QuitGame()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
           
        
    }

    public void LateUpdate()
    {
        QuitGame();
    }
}