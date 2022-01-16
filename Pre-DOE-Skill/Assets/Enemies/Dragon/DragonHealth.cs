using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHealth : MonoBehaviour,IEnemyHealthManager,IBoss
{
        
    public delegate void Death();

    private Death death;
    
    public float Health = 100;
    public int currRoom;
    private DragonController controller;
    private SpriteRenderer renderer;
    public bool isBoss;
    private bool spawned = false;

    private BossRoomMan currBossRoom;

    private void Start()
    {
        controller = gameObject.GetComponent<DragonController>();
        renderer = gameObject.GetComponent<SpriteRenderer>();

        controller.enabled = false;
        renderer.enabled = false;
    }

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

    public void JoinDeath(ref IRoomMan room)
    {
        death += room.DeathCounter;    
    }

    public void Spawn(ref BossRoomMan bossRoom)
    {
        if (isBoss && !spawned)
        {
            spawned = true;
            currBossRoom = bossRoom;
            controller.enabled = true;
            renderer.enabled = true;
        }
    }

    public bool IsBoss() => isBoss;
    public void OnDeath(){
        if (isBoss)
        {
            currBossRoom?.LevelOver();
        }
    }
}
