using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomMan : MonoBehaviour,IRoomMan
{
    // Start is called before the first frame update    
    List<IEnemyHealthManager> Enemies;
    public int ECNT;
    public Collider2D roomArea;
    public int roomNumber;
    public IBoss levelBoss;
    public int Dead;
    public GameObject nextBlock;
    void Start()
    {
        Enemies = gameObject.GetComponentsInChildren<IEnemyHealthManager>()
            .Where(x => !isBoss(x))
            .ToList();
        IBoss[] boss = gameObject.GetComponentsInChildren<IBoss>()
            .Where(x => x.IsBoss())
            .ToArray();
        
        ECNT = Enemies.Count;
        foreach (IEnemyHealthManager enemy in Enemies)
        {
            var roomMan = gameObject.GetComponent<IRoomMan>();
            enemy.JoinDeath(ref roomMan);
        }
        print(boss.Length);
        levelBoss = boss[0];
        
        nextBlock.SetActive(false);
    }
    bool isBoss(IEnemyHealthManager enemy){
        print(enemy.GetType());
        if (enemy.GetType().GetInterfaces().Contains(typeof(IBoss)))
        {
            IBoss boss = (IBoss) enemy;
            print(boss.GetType());
            return boss.IsBoss();
        }
        return false;
    }
    public void DeathCounter() => Dead++;
    // Update is called once per frame
    void Update()
    {
        if (ECNT <= Dead)
        {
            var bossRoomMan = gameObject.GetComponent<BossRoomMan>();
            levelBoss.Spawn(ref bossRoomMan);
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

    public void LevelOver()
    {
        nextBlock.SetActive(true);
    }
    
}
