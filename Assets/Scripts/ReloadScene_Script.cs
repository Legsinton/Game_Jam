using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReloadScene_Script : MonoBehaviour
{
    public void ReloadScene()
    {

        /*Scene currentScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentScene.name);*/

        SceneManager.LoadScene("Title_Screen");
    }


}
