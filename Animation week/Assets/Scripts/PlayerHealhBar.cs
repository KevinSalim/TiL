using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealhBar : MonoBehaviour 
{
    public Image Fillimage;
    public RunnerController Player;

    public Gradient gradient;

	
	// Update is called once per frame
	void Update () 
    {
		if (Fillimage && Player)
        {
            float percentHealth = Player.CurrentHealth / Player.MaxHealth;
            Fillimage.fillAmount = percentHealth;

            Fillimage.color = gradient.Evaluate(percentHealth);
        }
	}
}
