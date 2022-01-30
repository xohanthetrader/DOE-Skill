using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextBlock : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        string Level = SceneManager.GetActiveScene().name;
        string lvlblock = Level.Substring(0, Level.Length - 2);
        bool sameLevel = true;
        string nextLevelStr = "";
        while (sameLevel)
        {
            int LVLCNT = LevelGroups.GetNames(typeof(LevelGroups)).Length;
            int chosenLevelNum = Random.Range(0,LVLCNT);
            LevelGroups nextLevel = ((LevelGroups[])LevelGroups.GetValues(typeof(LevelGroups)))[chosenLevelNum];
            nextLevelStr = nextLevel.ToString();
            sameLevel = nextLevelStr != Level;
        }
        
        SceneManager.LoadScene($"{nextLevelStr}-1");
        
    }
}
