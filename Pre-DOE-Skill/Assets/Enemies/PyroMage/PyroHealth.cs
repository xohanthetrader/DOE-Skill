using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyroHealth : MonoBehaviour,IEnemyHealthManager
{
    [SerializeField]
    private float Health = 75;

    public int currRoom;

    public PlayerHealthBar myHealth;

    private void Awake()
    {
        myHealth.Init(Health,Health);
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

    public void JoinDeath(ref RoomMan room)
    {
        throw new NotImplementedException();
    }
}
