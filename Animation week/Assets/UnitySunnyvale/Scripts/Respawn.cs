using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{

	private bool _finished;
	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
	    if (col.gameObject.tag == "Player")
	    {
			_finished = true; 
			Application.LoadLevel(Application.loadedLevel);
			//col.gameObject.SetActive(false);
	    }
	  
	}

	void OnGUI()
	{
		if(_finished)
		{
			if(GUI.Button(new Rect(Screen.width-80,Screen.height+40, 20,20),"Play Again?"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}