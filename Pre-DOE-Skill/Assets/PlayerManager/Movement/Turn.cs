using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Turn : MonoBehaviour
{
    public Camera cam;
    
    private Vector3 raw;
    
    public void FindMouse(InputAction.CallbackContext context)
    {
        raw = context.ReadValue<Vector2>();
    }

    float LookAngle()
    {
        Vector2 dir = cam.ScreenToWorldPoint(raw) - transform.position;
        return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * LookAngle());
    }
}
