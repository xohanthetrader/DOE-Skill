using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnGremlins : MonoBehaviour
{
    public UnityEvent spawnGremlin;
    public void OnDestroy()
    {
        spawnGremlin.Invoke();
    }
}
