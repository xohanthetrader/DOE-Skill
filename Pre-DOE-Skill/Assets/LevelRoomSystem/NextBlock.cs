using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextBlock : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            string Level = SceneManager.GetActiveScene().name;
            string lvlblock = Level.Substring(0, Level.Length - 2);
            int OtherLVLCNT = LevelGroups.GetNames(typeof(LevelGroups)).Length - 1;
            int chosenLevelNum = Random.Range(0,OtherLVLCNT);
            LevelGroups[] nextLevels = (LevelGroups[])LevelGroups.GetValues(typeof(LevelGroups));
            string[] nextLevelsStr = nextLevels.Select(x => x.ToString()).Where(x => x != lvlblock).ToArray();
            string nextLevelStr = nextLevelsStr[chosenLevelNum];
            SceneManager.LoadScene($"{nextLevelStr}-1");
        }
    }
}
