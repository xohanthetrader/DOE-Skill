using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TrapTurret : MonoBehaviour
{
    public Sprite hidden;
    public Sprite revealed;
    public SpriteRenderer toChange;
    private bool isRevealed = false;
    private Transform player;
    private bool canShoot;
    public GameObject bullet;
    public Transform Firepoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            toChange.sprite = revealed;
            isRevealed = true;
            canShoot = true;
            player = other.GetComponent<Transform>();
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.tag = "Enemy";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //toChange.sprite = hidden;
            isRevealed = false;
            //transform.rotation = quaternion.Euler(0,0,0);
            //gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //gameObject.tag = "Terrain";
        }
    }

    void Start()
    {
        toChange.sprite = hidden;
        canShoot = true;
    }
    
    void Update()
    {
        if (isRevealed)
        {
            Vector2 dir = player.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            if (canShoot)
            {
                StartCoroutine(Shoot(4));
            }
        }
        else
        {
            StopAllCoroutines();
        }
    }
    
    IEnumerator Shoot(int shotsLeft)
    {
        canShoot = false;

        if (shotsLeft > 0)
        {
            GameObject myBullet = Instantiate(bullet,Firepoint.position,Firepoint.rotation);
            Rigidbody2D myBulletPhysics = myBullet.GetComponent<Rigidbody2D>();
            myBulletPhysics.AddForce(Firepoint.up * 5,ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.25f);
            shotsLeft--;
            StartCoroutine(Shoot(shotsLeft));
        }
        else
        {
            yield return new WaitForSeconds(2);
            canShoot = true;
        }
        
    }
}

