using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDamage : MonoBehaviour
{
    public float damage = 20;
    public float bonusDamage;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealthManager healthManager = other.gameObject.GetComponent<EnemyHealthManager>();
            healthManager.TakeDamage(damage + bonusDamage,BulletTypes.FireBall);
        }
    }
}
