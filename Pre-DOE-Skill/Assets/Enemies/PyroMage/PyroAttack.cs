using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyroAttack : MonoBehaviour
{
    [SerializeField]
    private bool canAttack = true;
    public GameObject FireBullet;
    
    public void Attack(Vector2 player,Vector2 Attacker)
    {
        
        if (canAttack)
        {
            canAttack = false;
            Vector2 dir = (player - Attacker);
            Quaternion Rotation = Quaternion.Euler(dir * Vector3.forward);
            GameObject clone = Instantiate(FireBullet, transform.position, Rotation);
            Rigidbody2D cloneRB = clone.GetComponent<Rigidbody2D>();
            cloneRB.AddForce(0.5f* dir,ForceMode2D.Impulse);
            Transform cloneRot = clone.GetComponent<Transform>();
            cloneRot.rotation = Rotation;
            StartCoroutine(Recover());
        }
    }

    IEnumerator Recover()
    {
        yield return new WaitForSeconds(5);
        canAttack = true;
    }
}
