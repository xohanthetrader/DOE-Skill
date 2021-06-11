using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateBoss : MonoBehaviour
{
    public bool Active = false;
    public UnityEvent BossPrep;

    public void Activate() => Active = true;

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Active)
        {
            BossPrep.Invoke();
        }
    }
}

