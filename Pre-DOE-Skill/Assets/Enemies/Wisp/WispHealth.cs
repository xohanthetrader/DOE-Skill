using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispHealth : MonoBehaviour,IEnemyHealthManager
{
    public float currentHealth = 100;
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage, BulletTypes types)
    {
        if (types == BulletTypes.FireBall)
        {
            currentHealth -= damage * 2;
            return;
        }

        currentHealth -= damage;
    }
}
