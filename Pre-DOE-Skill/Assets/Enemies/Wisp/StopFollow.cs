using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

public class StopFollow : MonoBehaviour
{
    private Transform self;
    public Transform player;
    public AIPath toDisable;

    private void Awake()
    {
        self = gameObject.transform;
    }

    private void Update()
    {
        Vector2 distance = self.position - player.position;
        if (distance.magnitude <= 1)
        {
            toDisable.enabled = false;
        }
        else
        {
            toDisable.enabled = true;
        }
    }
}
