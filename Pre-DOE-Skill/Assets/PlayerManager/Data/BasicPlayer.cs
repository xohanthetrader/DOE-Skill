using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayer : MonoBehaviour,IPlayerHealthManager
{
    public PlayerData myPlayer;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (myPlayer.Health <= 0)
        {
            myPlayer.Health = myPlayer.MAXHealth;
        }
    }

    public void CheckHealth()
    {
        if (myPlayer.Health <= 0)
        {
            Destroy(gameObject);
        }

        if (myPlayer.Health > myPlayer.MAXHealth)
        {
            myPlayer.Health = myPlayer.MAXHealth;
        }
    }

    public void TakeDamage(float damage, EnemyDamageTypes type)
    {
        myPlayer.Health -= damage;
    }

    private void Update()
    {
        CheckHealth();
    }
}
