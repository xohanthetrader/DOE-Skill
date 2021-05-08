using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloomManager : MonoBehaviour
{
    public Volume _bloom;

    private void Awake()
    {
        _bloom = gameObject.GetComponent<Volume>();
        _bloom.enabled = false;
    }

    public void WeaponSwap(InputAction.CallbackContext context)
    {
        float button = context.ReadValue<float>();
        if (button == 1)
        {
            _bloom.enabled = true;
        } else if(button == -1)
        {
            _bloom.enabled = false;
        }
    }
}
