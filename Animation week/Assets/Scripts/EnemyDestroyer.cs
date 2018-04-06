using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    public string EnemyTag = "Enemy";

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == EnemyTag)
        {
            Destroy(other.collider.gameObject, 1f);
        }
    }
}
