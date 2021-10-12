using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyDamageTypes dmgtype;
    public LayerMask player;
    [SerializeField] private SpriteRenderer Trap;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Trap.enabled = true;
            StartCoroutine(BlowUpTime());
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IPlayerHealthManager player = other.GetComponent<IPlayerHealthManager>();
            player?.TakeDamage(5 * Time.deltaTime,dmgtype);
        }
    }

    IEnumerator BlowUpTime()
    {
        yield return new WaitForSeconds(5);
        Trap.color = Color.blue;
        yield return new WaitForSeconds(0.2f);
        Collider2D Player = Physics2D.OverlapCircle(transform.position, 1, player);
        if (Player != null)
        {
            Player.GetComponent<IPlayerHealthManager>()?.TakeDamage(50,EnemyDamageTypes.Boom);
        }
    }
}
