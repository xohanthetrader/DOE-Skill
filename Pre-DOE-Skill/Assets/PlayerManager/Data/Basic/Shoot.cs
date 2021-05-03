using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firepoint;
    public float empowered = 0;
    public bool isGrowing;

    public float bulletForce = 5;


    public void Fire(InputAction.CallbackContext context)
    {
        if (enabled)
        {
            Shooting(context.ReadValueAsButton());
        }
    }


    void Shooting(bool buttonVal)
    {
        isGrowing = buttonVal;
        float speedMultiplier = 1;
        if (!buttonVal)
        {
            GameObject clone = Instantiate(bullet,firepoint.position,firepoint.rotation);
            Transform cloneTransform = clone.GetComponent<Transform>();
            if (empowered/4 > 1)
            {
                cloneTransform.localScale *= empowered/3;
            }

            if (empowered/2 > 2)
            {
                speedMultiplier = empowered / 2;
            }
            FireballDamage adjust = clone.GetComponent<FireballDamage>();
            adjust.bonusDamage = empowered;
            Rigidbody2D clonerb = clone.GetComponent<Rigidbody2D>();
            clonerb.AddForce(firepoint.up * (bulletForce/speedMultiplier),ForceMode2D.Impulse);
            empowered = 0;
        }
    }

    void Grow()
    {
        if (isGrowing && empowered < 30)
        {
            empowered += Time.deltaTime * 10;
        }
    }

    private void Update()
    {
        Grow();
    }
}
