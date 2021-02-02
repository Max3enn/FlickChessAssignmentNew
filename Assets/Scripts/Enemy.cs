using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;
    public float health = 4f;

    public static int EnemiesAlive = 0;

    void Start ()
    {
        EnemiesAlive++;
    }
    void OnCollisionEnter2D (Collision2D colInfo)
    {
            if (colInfo.relativeVelocity.magnitude > health)
            {
                StartCoroutine(Die());
            }
    }
    IEnumerator Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

        EnemiesAlive--;
        if (EnemiesAlive <= 0)
            Debug.Log("LEVEL WON");

        Destroy(gameObject);
    }
    
}
