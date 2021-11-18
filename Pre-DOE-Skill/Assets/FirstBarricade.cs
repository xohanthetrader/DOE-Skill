using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class FirstBarricade : MonoBehaviour
{
    public TilemapCollider2D barrier;
    //public UnityEvent Spawnnext;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Spawnnext.Invoke();
            gameObject.GetComponent<TilemapRenderer>().enabled = false;
            barrier.enabled = false;
        }
    }
}
