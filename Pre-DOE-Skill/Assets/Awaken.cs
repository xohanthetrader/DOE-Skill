using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Awaken : MonoBehaviour
{
    public UnityEvent<int> awakener;

    public void awaken()
    {
        awakener.Invoke(1);
    }
}
