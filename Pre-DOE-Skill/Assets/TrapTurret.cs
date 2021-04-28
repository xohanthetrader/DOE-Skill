using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TrapTurret : MonoBehaviour
{
    public Sprite hidden;
    public Sprite revealed;
    public SpriteRenderer toChange;
    private bool isRevealed = false;
    public Transform player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            toChange.sprite = revealed;
            isRevealed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            toChange.sprite = hidden;
            isRevealed = false;
            transform.rotation = quaternion.Euler(0,0,0);
        }
    }

    void Start()
    {
        toChange.sprite = hidden;
    }
    
    void Update()
    {
        if (isRevealed)
        {
            Vector2 dir = player.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }    
    }
}
