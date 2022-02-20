using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class PyroHealth : MonoBehaviour,IEnemyHealthManager
{
    [SerializeField]
    private float Health = 75;

    public int currRoom;

    public PlayerHealthBar myHealth;
    
    public delegate void Death();
    
    public SpriteRenderer sprite;
    public AIPath path;
    public FollowManager mgr;
    public GameObject bar;

    private Death death;

    private void Awake()
    {
        myHealth.Init(Health,Health);
        sprite.enabled = false;
        path.enabled = false;
        mgr.enabled = false;
        bar.SetActive(false);
    }

    public void TakeDamage(float damage, BulletTypes types)
    {
        switch (types)
        {
            case BulletTypes.FireBall:
                break;
            default:
                Health -= damage;
                break;
        }
        myHealth.UpdateHealth(Health);
    }

    private void Update()
    {
        CheckHealth();   
    }

    void CheckHealth()
    {
        if (Health<= 0)
        {
            death?.Invoke();
            Destroy(gameObject);
        }
    }
    public void RoomActive(int room)
    {
        if (room == currRoom)
        {
            gameObject.SetActive(true);
            sprite.enabled = true;
            path.enabled = true;
            mgr.enabled = true;
            bar.SetActive(true);
        }
    }

    public void JoinDeath(ref IRoomMan room)
    {
        death += room.DeathCounter;
    }

    
}
