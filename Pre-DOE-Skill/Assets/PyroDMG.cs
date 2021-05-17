using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyroDMG : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                IPlayerHealthManager healthManager = other.gameObject.GetComponent<IPlayerHealthManager>();
                healthManager.TakeDamage(5,EnemyDamageTypes.PyroFlame);
                healthManager.AddStatus(StatusTypes.Burn);
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Terrain"))
            {
                Destroy(gameObject);
            }
        }
    }
}
