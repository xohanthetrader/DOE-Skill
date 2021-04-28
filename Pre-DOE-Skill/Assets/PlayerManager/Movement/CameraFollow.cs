using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector2 wasd;
    public Vector2 offSet;
    private readonly Vector3 _allignCamera = new Vector3(0, 0, 10);
    private Vector2 _offSet;
    

    private void Awake()
    {
        transform.position = player.position - _allignCamera;
    }

    public void OnWASD(InputAction.CallbackContext context)
    {
        wasd = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        OffsetFade();
        print(_offSet);
       
        transform.position = player.position + (Vector3)_offSet - _allignCamera;
    }

    void OffsetFade()
    {
        if (wasd.x == 0)
        {
            if (_offSet.x > 0)
            {
                _offSet.x -= 1 * Time.deltaTime;
            }

            if (_offSet.x < 0)
            {
                _offSet.x += 1 * Time.deltaTime;
            }
        }
        else
        {
            if (_offSet.x > - offSet.x && _offSet.x < offSet.x)
            {
                if (wasd.x > 0)
                {
                    _offSet.x += 1 * Time.deltaTime;
                }

                if (wasd.x < 0)
                {
                    _offSet.x -= 1 * Time.deltaTime;
                }
            }
        }
        if (wasd.y == 0)
        {
            if (_offSet.y > 0)
            {
                _offSet.y -= 1 * Time.deltaTime;
            }

            if (_offSet.y < 0)
            {
                _offSet.y += 1 * Time.deltaTime;
            }
        }
        else
        {
            if (_offSet.y > - offSet.y && _offSet.y < offSet.y)
            {
                if (wasd.y > 0)
                {
                    _offSet.y += 1 * Time.deltaTime;
                }

                if (wasd.y < 0)
                {
                    _offSet.y -= 1 * Time.deltaTime;
                }
            }
        }

        if (_offSet.x < -offSet.x)
        {
            _offSet.x = -offSet.x;
        }
        if (_offSet.x > offSet.x)
        {
            _offSet.x =  offSet.x;
        }
        if (_offSet.y < -offSet.y)
        {
            _offSet.y = -offSet.y;
        }
        if (_offSet.y > offSet.y)
        {
            _offSet.y =  offSet.y;
        }
    }
}