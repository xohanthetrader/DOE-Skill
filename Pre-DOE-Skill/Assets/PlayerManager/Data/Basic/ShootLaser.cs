using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootLaser : MonoBehaviour
{
    public bool isShooting;
    public Transform Firepoint;
    public LineRenderer laser;
    public void ONClick(InputAction.CallbackContext context)
    {
        if (enabled)
        {
            isShooting = context.ReadValueAsButton();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            Shoot();
            laser.enabled = true;
        }
        else
        {
            laser.enabled = false;
        }
    }

    void Shoot()
    { 
       RaycastHit2D hitinfo = Physics2D.Raycast(Firepoint.position, Firepoint.up);
       if (hitinfo)
       {
           if (hitinfo.transform.CompareTag("Enemy"))
           {
               IEnemyHealthManager enemy = hitinfo.transform.GetComponent<IEnemyHealthManager>();
               enemy.TakeDamage(40 * Time.deltaTime,BulletTypes.LightningBolt);
           }
           laser.SetPosition(0,Firepoint.position);
           laser.SetPosition(1,hitinfo.point);
       }
       else
       {
           laser.SetPosition(0,Firepoint.position);
           laser.SetPosition(1,Firepoint.position + Firepoint.up * 100);
       }
       
    }
}
