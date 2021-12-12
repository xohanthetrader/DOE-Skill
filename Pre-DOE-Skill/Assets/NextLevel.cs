using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string Level = SceneManager.GetActiveScene().name;
            
            int index = int.Parse(Level.Last().ToString());
            print(Level);
            

            SceneManager.LoadScene(Level.Substring(0,Level.Length-1) + $"{index + 1}");
            
        }
    }
}
