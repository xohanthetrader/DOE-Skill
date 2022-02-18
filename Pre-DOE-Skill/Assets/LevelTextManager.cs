using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTextManager : MonoBehaviour
{
    public TextMeshProUGUI textModule;

    public LevelCompleteData completed;
    // Start is called before the first frame update
    void Start()
    {
        Scene currScene = SceneManager.GetActiveScene();
        textModule.text = $"{completed.Completed}-{currScene.name}";
    }
}
