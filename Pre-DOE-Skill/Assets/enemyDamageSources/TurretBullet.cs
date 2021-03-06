using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                IPlayerHealthManager healthManager = other.gameObject.GetComponent<IPlayerHealthManager>();
                healthManager.TakeDamage(2.5f,EnemyDamageTypes.TurretBullet);
                Destroy(gameObject);
            }
            else if (other.gameObject.CompareTag("Terrain"))
            {
                Destroy(gameObject);
            }
        }
    }
}
