using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dummy : MonoBehaviour,IEnemyHealthManager
{
    public BulletTypes dummyType;
    public UnityEvent Completer;
    [SerializeField] private bool Active;

    public void TakeDamage(float damage, BulletTypes types)
    {
        if (types == dummyType && Active)
        {
            Completer.Invoke();
        }
    }

    public void Activate() => Active = true;
}
