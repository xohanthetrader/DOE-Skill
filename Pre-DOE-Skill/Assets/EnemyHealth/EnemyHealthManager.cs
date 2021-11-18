using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyHealthManager
{
    public abstract void TakeDamage(float damage, BulletTypes types);

    public void RoomActive(int room);

    public void JoinDeath(ref RoomMan room);
}

