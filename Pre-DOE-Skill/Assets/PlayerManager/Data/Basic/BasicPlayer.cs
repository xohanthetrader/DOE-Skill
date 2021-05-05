using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicPlayer : MonoBehaviour,IPlayerHealthManager
{
    public PlayerData myPlayer;
    public PlayerHealthBar healthBar;
    public Shoot shoot;
    public ShootLaser laser;

    // Start is called before the first frame update
    void Awake()
    {
        if (myPlayer.Health <= 0)
        {
            myPlayer.Health = myPlayer.MAXHealth;
        }
        healthBar.Init(myPlayer.MAXHealth,myPlayer.Health);
        shoot.enabled = true;
        laser.enabled = false;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void CheckHealth()
    {
        if (myPlayer.Health <= 0)
        {
            //Will add gameover screen
           FindObjectOfType<Camera>().GetComponent<CameraFollow>().enabled = false;
           Destroy(gameObject);
        }

        if (myPlayer.Health > myPlayer.MAXHealth)
        {
            myPlayer.Health = myPlayer.MAXHealth;
        }
    }

    public void SwitchWeapon(InputAction.CallbackContext context)
    {
        float weaponNumber = context.ReadValue<float>();
        if (weaponNumber == -1)
        {
            shoot.enabled = true;
            laser.enabled = false;
        } else if (weaponNumber == 1)
        {
            shoot.enabled = false;
            laser.enabled = true;
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
