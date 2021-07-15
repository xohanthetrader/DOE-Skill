using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class DragonController : MonoBehaviour
{
    public Transform player;
    public RaycastHit2D hitinfo;
    public bool canShoot = true;
    public bool canSee = false;
    public bool inRange = true;
    public bool following;
    private Vector2 angle;
    public bool followSeystem;
    public bool Shooting;
    public LineRenderer fire;
    public Transform firepoint;
    public IPlayerHealthManager playerHealth;

    void Start()
    {
        fire.enabled = false;
        playerHealth = player.GetComponent<IPlayerHealthManager>();
        fire.startWidth = 0.5f;
        fire.endWidth = 0.5f;
    }
    private void FixedUpdate()
    {
        Vector2 dir = player.position - transform.position;
        inRange = dir.sqrMagnitude <= 25;
        angle = dir;
        hitinfo = Physics2D.Raycast(transform.position, dir);
        Debug.DrawRay(transform.position,dir,Color.blue,0,false);
        //Debug.DrawLine(transform.position,player.position,Color.red,0,false);
        canSee = hitinfo && hitinfo.transform.CompareTag("Player");
        
    }

    IEnumerator Shoot()
    {
        if (canShoot && inRange && canSee && !following)
        {
            canShoot = false;
            Shooting = true;
            yield return new WaitForSeconds(5);
            canShoot = true;
            Shooting = false;
        } 
        if (canSee && canShoot && !followSeystem && !Shooting)
        {
            followSeystem = true;
            following = true;
            yield return new WaitForSeconds(2.5f);
            following = false;
            yield return new WaitForSeconds(.5f);
            followSeystem = false;
        }
    }

    private void Update()
    {
        
        fire.SetPosition(0,firepoint.position);
        fire.SetPosition(1,player.position);
        
        StartCoroutine(Shoot());
        if (following && !inRange)
        {
            transform.rotation = Quaternion.Euler((Mathf.Atan2(angle.y,angle.x) * Mathf.Rad2Deg - 90) * Vector3.forward);
            transform.position += transform.up * (float)(2.5 * Time.deltaTime);
        }

        if (Shooting && inRange && canSee)
        {
            fire.enabled = true;
            
            playerHealth.TakeDamage(10*Time.deltaTime,EnemyDamageTypes.DragonFire);
            transform.rotation = Quaternion.Euler((Mathf.Atan2(angle.y,angle.x) * Mathf.Rad2Deg - 90) * Vector3.forward);
        }

        if (fire.enabled && !(Shooting && inRange && canSee))
        {
            fire.enabled = false;
        }
    }
}
