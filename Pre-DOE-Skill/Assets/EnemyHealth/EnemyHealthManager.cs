using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyHealthManager
{
    public abstract void TakeDamage(float damage, BulletTypes types);
    
}

