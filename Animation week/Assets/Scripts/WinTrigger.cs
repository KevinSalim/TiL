using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class WinTrigger : MonoBehaviour
{
    public string WinSceneName = "EndMenu";
    public UnityEvent OnTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Player")
        {
            SceneManager.LoadScene(WinSceneName);
            OnTrigger.Invoke();
        }
    }
}