using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Processors;

public class FinishKill : MonoBehaviour
{
    public int Dead = 0;
    public void Death() => Dead++;
    public UnityEvent finishQuest;

    private void Update()
    {
        if (Dead >= 6)
        {
            finishQuest.Invoke();
        }
    }
}
