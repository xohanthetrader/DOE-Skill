using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Animator;

    public void onClick(InputAction.CallbackContext context)
    {
        Animator.SetBool("Shooting",context.ReadValueAsButton());
    }
}
