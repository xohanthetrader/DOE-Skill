using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour
{
    public Sprite Idle;
    public Sprite Active;
    public SpriteRenderer self;

    private void Awake()
    {
        self = gameObject.GetComponent<SpriteRenderer>();
        self.sprite = Idle;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            self.sprite = Active;
        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            self.sprite = Idle;
        }
    }
}