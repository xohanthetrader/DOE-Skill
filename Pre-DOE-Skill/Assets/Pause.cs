using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject[] buttons;
    public void PauseGame()
    {
        Time.timeScale = 0;
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }
    }
}
