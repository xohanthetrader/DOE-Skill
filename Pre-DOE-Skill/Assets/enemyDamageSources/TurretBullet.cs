using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("test");
        if (other.gameObject.CompareTag("Player"))
        {
            IPlayerHealthManager healthManager = other.gameObject.GetComponent<IPlayerHealthManager>();
            healthManager.TakeDamage(10,EnemyDamageTypes.TurretBullet);
        }
    }
}
