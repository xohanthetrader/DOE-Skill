using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispAttack : MonoBehaviour
{
    public Transform swipePoint;
    public LayerMask player;
    public bool canAttack;

    private void Awake()
    {
        canAttack = true;
    }

    private void FixedUpdate()
    {
        if (canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    public IEnumerator Attack()
    {
        canAttack = false;
        yield return new WaitForSeconds(1);
        Collider2D Player = Physics2D.OverlapCircle(swipePoint.position, 1, player);
        if (Player != null)
        {
            Player.GetComponent<IPlayerHealthManager>().TakeDamage(10,EnemyDamageTypes.Wisp);
        }

        canAttack = true;
    }
}
