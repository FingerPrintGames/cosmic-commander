using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;

    [Tooltip("Increases Max Health by this value everytime an enemy dies.")]
    [SerializeField] int healthIncreaseValue = 1;

    int currentHealth = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
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
            maxHealth += healthIncreaseValue;
            enemy.RewardMoney();
        }
    }
}
