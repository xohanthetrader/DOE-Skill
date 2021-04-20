using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb;
    
    private Vector2 _moveState;
    public float speed = 5;
    
    public void OnWASD(InputAction.CallbackContext context)
    {
        _moveState = context.ReadValue<Vector2>();
        print(_moveState);
    }

    Vector2 ToMove()
    {
        return rb.position + _moveState * (speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(ToMove());
    }
}
