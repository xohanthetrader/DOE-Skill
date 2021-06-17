using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class QuestManager : MonoBehaviour
{
    public List<Quest> Quests;
    public bool questsStarted = false;
    public TextMeshProUGUI Text;

    private void Start()
    {
        Quests = new List<Quest>()
        {
            new Quest("Test your fireball on the red dummy to my right <br>Use left click to fire and hold to expand","FireballDummy"),
            new Quest("Now click 2 to switch to your laser and try that on the blue dummy <br>Click 1 to switch back ","LightningDummy"),
            new Quest("Go Into The boss room and fight","EnterBoss"),
            new Quest("Oh no there are more. Kill them","KillSmall"),
        };
        Dummy.toComplete += CompleteQuest;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            if (!questsStarted)
            {
                Quests[0].inProgress = true;
                questsStarted = true;
                print("QuestGranted");
                Text.text = Quests[0].Objective;
            }

            if (questsStarted)
            {
                int NextQuest = 0;
                for(int i = 0; i < Quests.Count; i++)
                {
                    if (Quests[i].inProgress)
                    {
                        goto NoNewQest;
                    }
                }

                for (int i = 0; i < Quests.Count; i++)
                {
                    if (Quests[i].Completed)
                    {
                        NextQuest = i + 1;
                    }
                }
                Quests[NextQuest].inProgress = true;
                Text.text = Quests[NextQuest].Objective;
            }
        }

        NoNewQest: ;
    }

    public void CompleteQuest(string objective)
    {
        for (int i = 0; i < Quests.Count; i++)
        {
            if (Quests[i].inProgress && Quests[i].ShortObj == objective)
            {
                Quests[i].inProgress = false;
                Quests[i].Completed = true;
                Text.text = "Quest Complete";
                if (i == 2)
                {
                    Quests[i++].inProgress = true;
                    Text.text = Quests[i++].Objective;
                }
                
            }
        }
    }

    public void HideState(bool doIHide) => gameObject.GetComponent<SpriteRenderer>().enabled = doIHide;
}
