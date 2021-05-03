using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDamage : MonoBehaviour
{
    public float damage = 20;
    public float bonusDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                IEnemyHealthManager healthManager = other.gameObject.GetComponent<IEnemyHealthManager>();
                healthManager.TakeDamage(damage + bonusDamage,BulletTypes.FireBall);
            }
        }
    }
}
