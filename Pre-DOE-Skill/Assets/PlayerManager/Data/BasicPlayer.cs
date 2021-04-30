using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicPlayer : MonoBehaviour,IPlayerHealthManager
{
    public PlayerData myPlayer;
    public Camera cam;
    public PlayerHealthBar healthBar;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (myPlayer.Health <= 0)
        {
            myPlayer.Health = myPlayer.MAXHealth;
        }
        healthBar.Init(myPlayer.MAXHealth,myPlayer.Health);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void CheckHealth()
    {
        if (myPlayer.Health <= 0)
        {
            //Will add gameover screen
            cam.GetComponent<CameraFollow>().enabled = false;
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
        healthBar.UpdateHealth(myPlayer.Health);
    }

    private void Update()
    {
        CheckHealth();
    }
}
