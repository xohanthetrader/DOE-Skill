using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomMan : MonoBehaviour
{
    [SerializeField] private int roomNumber;
    public Collider2D roomArea;
    [SerializeField]private int Dead = 0;
    public List<IEnemyHealthManager> Enemies;
    public int ECNT;
    private void Start()
    {
        Enemies = gameObject.GetComponentsInChildren<IEnemyHealthManager>().ToList();
        ECNT = Enemies.Count;
        foreach (IEnemyHealthManager enemy in Enemies)
        {
            var roomMan = gameObject.GetComponent<RoomMan>();
            enemy.JoinDeath(ref roomMan);
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

    private void Update()
    {
        if (Dead >= ECNT)
        {
            nextLevel();
        }
    }

    void nextLevel()
    {
        gameObject.GetComponent<TilemapRenderer>().enabled = false;
        gameObject.GetComponent<TilemapCollider2D>().enabled = false;
    }
    public void DeathCounter() => Dead++;
}
