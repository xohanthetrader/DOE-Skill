using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerHealthManager
{
    public void TakeDamage(float damage,EnemyDamageTypes type);
    public void CheckHealth();
    
}
