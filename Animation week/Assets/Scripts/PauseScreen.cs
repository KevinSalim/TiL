using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour 
{
    public GameObject MenuObject;
    private bool IsOpen = false;
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsOpen)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }	
	}
    public void OpenMenu()
    {
        IsOpen = true;
        MenuObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void CloseMenu()
    {
        IsOpen = false;
        MenuObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Loadscene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
