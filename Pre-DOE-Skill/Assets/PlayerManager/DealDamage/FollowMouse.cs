using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    public Transform player;
    public LineRenderer line;
    public float distance;
    

    public void Release(InputAction.CallbackContext context)
    {
        if (!context.ReadValueAsButton())
        {
            print("Self Destruct");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(Disable());

        }
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(0.2f);
        line.GetComponent<AddHitEffect>().effectExists = false;
        Destroy(gameObject);
    }
    private float GetAngle()
    {
        Vector2 direction = player.transform.position - line.GetPosition(1);
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
    }
    void Update()
    {
        transform.position = line.GetPosition(1) + distance * transform.up;
        transform.rotation = Quaternion.Euler(Vector3.forward * GetAngle());
    }
}
