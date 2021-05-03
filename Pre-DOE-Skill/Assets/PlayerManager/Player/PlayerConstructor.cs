using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerConstructor : MonoBehaviour
{
    public enum PlayerTypes
    {
        Basic,
    }
    
    public PlayerTypes playerType;

    private void Awake()
    {
        switch (playerType)
        {
            case PlayerTypes.Basic:
                gameObject.GetComponent<BasicPlayer>().enabled = true;
                break;
        }
    }
}
