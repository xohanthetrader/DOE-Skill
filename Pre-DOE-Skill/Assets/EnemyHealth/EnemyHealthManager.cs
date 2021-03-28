using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyHealthManager : MonoBehaviour
{
    public abstract void TakeDamage(float damage, BulletTypes types);
    
}

