using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firepoint;

    public float bulletForce = 5;
    
    public void Fire(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 0)
        {
            GameObject clone = Instantiate(bullet,firepoint.position,firepoint.rotation);
            Rigidbody2D clonerb = clone.GetComponent<Rigidbody2D>();
            clonerb.AddForce(firepoint.up * bulletForce,ForceMode2D.Impulse);
        }
    }
}
