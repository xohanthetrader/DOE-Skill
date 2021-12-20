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
        int LVLCNT = LevelGroups.GetNames(typeof(LevelGroups)).Length;
        int chosenLevelNum = Random.Range(0,LVLCNT);
        LevelGroups Level = ((LevelGroups[])LevelGroups.GetValues(typeof(LevelGroups)))[chosenLevelNum];
        SceneManager.LoadScene($"{Level.ToString()}-1");
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
