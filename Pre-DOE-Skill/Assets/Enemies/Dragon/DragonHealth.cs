using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHealth : MonoBehaviour,IEnemyHealthManager,IBoss
{
    
    
    public float Health = 100;
    public int currRoom;

    public bool isBoss;
    public void TakeDamage(float damage, BulletTypes types)
    {
        print("damge taken");
        Health -= damage * 0.5f;
        if (Health <= 0)
        {
            OnDeath();
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

    public void JoinDeath(ref FinalRoom room)
    {
        throw new NotImplementedException();
    }

    public bool IsBoss() => isBoss;
    public void OnDeath(){
        if (isBoss)
        {
            
        }
    }
}
