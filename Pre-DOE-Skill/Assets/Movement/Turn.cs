using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Turn : MonoBehaviour
{
    public Camera cam;
    
    private Vector3 WorldMousePos;
    
    public void FindMouse(InputAction.CallbackContext context)
    {
        Vector2 raw = context.ReadValue<Vector2>();
        WorldMousePos = cam.ScreenToWorldPoint(raw);
        //Vector2 resdiv2 = new Vector2( (float) Screen.currentResolution.width/2,  (float) Screen.currentResolution.height/2) ;

    }

    float LookAngle()
    {
        Vector2 dir = WorldMousePos - transform.position;
        return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward * LookAngle());
    }
}
