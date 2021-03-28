using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : EnemyHealthManager
{
    private float maxHealth = 100;
    public float currentHealth;
    public void Start()
    {
        currentHealth += maxHealth;
    }

    public override void TakeDamage(float damage, BulletTypes types)
    {
        currentHealth -= damage;
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
