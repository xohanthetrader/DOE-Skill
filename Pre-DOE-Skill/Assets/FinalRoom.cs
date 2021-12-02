using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FinalRoom : MonoBehaviour
{
    // Start is called before the first frame update
    private List<IEnemyHealthManager> Enemies;
    public Collider2D roomArea;
    public int roomNumber;
    private int ECNT;
    private int Dead = 0;

    void Start()
    {
        Enemies = gameObject.GetComponentsInChildren<IEnemyHealthManager>().ToList();
        ECNT = Enemies.Count;
        foreach (IEnemyHealthManager enemy in Enemies)
        {
            var roomMan = gameObject.GetComponent<FinalRoom>();
            enemy.JoinDeath(ref roomMan);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ECNT >= Dead)
        {
            
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
