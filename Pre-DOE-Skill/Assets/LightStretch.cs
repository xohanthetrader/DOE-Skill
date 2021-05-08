using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightStretch : MonoBehaviour
{
    // Start is called before the first frame update
    public LineRenderer line;
    public Light2D light;
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        light = gameObject.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        light.enabled = line.enabled;
    }
}
