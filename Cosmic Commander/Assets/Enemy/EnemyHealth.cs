using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealth = 0;

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    void OnParticleCollision(GameObject other)
    {
            Debug.Log("detected");
            ProcessHit();
    }

    void ProcessHit()
    {
        currentHealth--;
        ProcessDeath();
    }

    void ProcessDeath()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
