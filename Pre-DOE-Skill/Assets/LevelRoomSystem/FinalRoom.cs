using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalRoom : MonoBehaviour,IRoomMan
{
    // Start is called before the first frame update
    private List<IEnemyHealthManager> Enemies;
    public Collider2D roomArea;
    public int roomNumber;
    public int ECNT;
    public int Dead = 0;
    public GameObject NextLevel;

    void Start()
    {
        Enemies = gameObject.GetComponentsInChildren<IEnemyHealthManager>().ToList();
        ECNT = Enemies.Count;
        foreach (IEnemyHealthManager enemy in Enemies)
        {
            var roomMan = gameObject.GetComponent<IRoomMan>();
            enemy.JoinDeath(ref roomMan);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ECNT <= Dead)
        {
            NextLevel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            roomArea.BroadcastMessage("RoomActive",roomNumber);
            roomArea.enabled = false;
        }
    }

    public void DeathCounter() => Dead++;
}
