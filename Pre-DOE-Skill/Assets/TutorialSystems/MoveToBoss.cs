using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToBoss : MonoBehaviour
{
    [SerializeField]private Transform moveto;
    public void mtb()
    {
        transform.position = moveto.position;
    }
}
