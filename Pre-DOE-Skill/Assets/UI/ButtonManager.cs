using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public PlayerData[] allPlayers;
    
    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scenes/Test");
        foreach (PlayerData player in allPlayers)
        {
            player.Health = player.MAXHealth;
        }
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
        foreach (PlayerData player in allPlayers)
        {
            player.Health = player.MAXHealth;
        }
    }

    public void Quit()
    {
        Application.Quit();
        print("Quit");
    }
}
