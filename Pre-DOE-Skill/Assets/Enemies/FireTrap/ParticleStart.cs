using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStart : MonoBehaviour
{
    public GameObject ParitcleSystem;
    public void activate()
    {
        ParitcleSystem.SetActive(true);
    }
}
