using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour 
{
    public string SceneName = "Week1 absence";

    public void StartGame()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
