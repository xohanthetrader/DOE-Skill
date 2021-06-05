using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireStatus : MonoBehaviour
{
    [SerializeField]
    private  Image flame;

    private void Awake() => flame.enabled = false;


    public void Activate() => flame.enabled = true;


    public void Deactivate() => flame.enabled = false;

}
