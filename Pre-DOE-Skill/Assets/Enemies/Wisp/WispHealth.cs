using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class WispHealth : MonoBehaviour,IEnemyHealthManager
{
    public int currRoom;
    public SpriteRenderer sprite;
    public AIPath path;
    public StopFollow AIman;
    [SerializeField] private new Light2D light;

    public delegate void Death();

    private Death death;

    public float currentHealth = 100;

    private void Awake()
    {
        sprite.enabled = false;
        path.enabled = false;
        AIman.enabled = false;
        light.enabled = false;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            death.Invoke();
            Destroy(gameObject);
        }
    }

    public void JoinDeath(ref RoomMan room)
    {
        death += room.DeathCounter;
        print("we have a joiner");
    }

    public void JoinDeath(ref FinalRoom room)
    {
        death += room.DeathCounter;
        print("we have a joiner");
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
    public void RoomActive(int room)
    {
        print("Called");
        if (room == currRoom)
        {
            enabled = true;
            sprite.enabled = true;
            sprite.enabled = true;
            AIman.enabled = true;
            light.enabled = true;
        }
    }

}
