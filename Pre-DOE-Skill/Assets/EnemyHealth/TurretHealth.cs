using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : MonoBehaviour,IEnemyHealthManager
{
    // Start is called before the first frame update
    private const float MAXHealth = 50;
    public float currentHealth;

    private void Start()
    {
        currentHealth = MAXHealth;
    }

    public void TakeDamage(float damage, BulletTypes types)
    {
        if (types == BulletTypes.FireBall)
        {
            currentHealth -= damage / 2;
        }
        else if (types == BulletTypes.LightningBolt)
        {
            currentHealth -= damage * 2;
        }
        else
        {
            currentHealth -= damage;
        }
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
