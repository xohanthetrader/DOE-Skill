using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootLaser : MonoBehaviour
{
    public bool isShooting;
    public Transform Firepoint;
    public LineRenderer laser;
    public float laserWidth;
    private bool _isShooting;
    public void ONClick(InputAction.CallbackContext context)
    {
        if (enabled)
        {
            _isShooting = context.ReadValueAsButton();
            StartCoroutine(WaitForHands());
        }
    }

    IEnumerator WaitForHands()
    {
        if (_isShooting)
        {
            yield return new WaitForSeconds(0.25f);
        }
        else
        {
            yield return new WaitForSeconds(0);
        }

        isShooting = _isShooting;
    }

    private void Awake()
    {
        laser.startWidth = laserWidth;
        laser.endWidth = laserWidth;
    }

    private void OnDisable()
    {
        laser.enabled = false;
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
