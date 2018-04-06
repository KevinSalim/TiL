using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour 
{
    public float DamageValue = 25f;
    public string TargetTag = "Player";

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TargetTag))
        {
            Rigidbody2D rb = collision.rigidbody;
            if (rb != null)
            {
                RunnerController rc = rb.GetComponent<RunnerController>();
                if (rc != null)
                {
                    rc.TakeDamage(DamageValue);
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
