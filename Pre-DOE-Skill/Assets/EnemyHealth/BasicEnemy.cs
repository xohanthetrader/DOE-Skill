using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour,IEnemyHealthManager
{
    private float maxHealth = 100;
    public int currRoom;
    public float currentHealth;
    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage, BulletTypes types)
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
    public void RoomActive(int room)
    {
        if (room == currRoom)
        {
            gameObject.SetActive(true);
        }
    }

    public void JoinDeath(ref FinalRoom room)
    {
        throw new NotImplementedException();
    }

    public void JoinDeath(ref RoomMan room)
    {
        throw new NotImplementedException();
    }
}
