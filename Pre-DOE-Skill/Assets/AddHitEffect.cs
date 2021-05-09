using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHitEffect : MonoBehaviour
{
    public LineRenderer line;
    public bool effectExists;
    public Transform player;
    public GameObject effect;

    private void Start()
    {
        effectExists = false;
    }

    private float GetAngle()
    {
        Vector2 direction = player.transform.position - line.GetPosition(1);
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
    }
    
    private void Update()
    {
        if (line.enabled && !effectExists)
        {
            
            GameObject myEffect = Instantiate(effect, line.GetPosition(1) - 0.3f * transform.up,Quaternion.Euler(Vector3.forward * GetAngle()));
            FollowMouse  myMouse = myEffect.GetComponent<FollowMouse>();
            myMouse.line = line;
            myMouse.player = player;
            effectExists = true;
        }
    }
}
