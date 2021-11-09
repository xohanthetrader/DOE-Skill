using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapManager : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyDamageTypes dmgtype;
    public LayerMask player;
    [SerializeField] private SpriteRenderer Trap;
    private IPlayerHealthManager playerHealthManager;
    public UnityEvent AdditionalInstructions;
    public ParticleSystem smoulder;
    private bool finished;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Trap.enabled = true;
            playerHealthManager = other.GetComponent<IPlayerHealthManager>();
            StartCoroutine(BlowUpTime());
            AdditionalInstructions.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !finished)
        {
            playerHealthManager?.TakeDamage(10 * Time.deltaTime,dmgtype);

        }
    }



    IEnumerator BlowUpTime()
    {
        yield return new WaitForSeconds(5);
        Trap.color = Color.grey;

        yield return new WaitForSeconds(0.2f);
        Collider2D Player = Physics2D.OverlapCircle(transform.position, 1, player);
        if (Player != null)
        {
            Player.GetComponent<IPlayerHealthManager>()?.TakeDamage(50,EnemyDamageTypes.Boom);
        }


        var main = smoulder.main;
        main.startColor = Color.black;

        finished = true;
    }
}
