using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMain : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera main;
    // Update is called once per frame
    void Update()
    {
        transform.position = main.transform.position;
    }
}
