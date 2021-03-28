using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplode : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Terrain"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        StartCoroutine(Fly());
    }

    IEnumerator Fly()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
