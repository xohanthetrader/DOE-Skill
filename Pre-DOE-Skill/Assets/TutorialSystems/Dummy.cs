using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dummy : MonoBehaviour,IEnemyHealthManager
{
    public BulletTypes dummyType;
    public delegate void Completer(string Objective);
    public static event Completer toComplete;

    public UnityEvent ActivateBoss;

    private void Start()
    {
        dummyType = BulletTypes.FireBall;
    }

    public void TakeDamage(float damage, BulletTypes types)
    {
        if (types == dummyType)
        {
            toComplete.Invoke(Objective());
            dummyType = BulletTypes.LightningBolt;
            if(types == BulletTypes.LightningBolt) ActivateBoss.Invoke();
        }
    }

    string Objective()
    {
        return dummyType switch
        {
            BulletTypes.FireBall => "FireballDummy",
            BulletTypes.LightningBolt => "LightningDummy",
            _ => throw new NotImplementedException()
        };
    }
}
