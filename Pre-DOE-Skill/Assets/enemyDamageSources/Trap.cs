using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IPlayerHealthManager toDealDamage = other.GetComponent<IPlayerHealthManager>();
            toDealDamage.TakeDamage(10 * Time.deltaTime,EnemyDamageTypes.Traps);
            print("owwwww");
        }       
    }
}
