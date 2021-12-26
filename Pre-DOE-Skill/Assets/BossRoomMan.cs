using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomMan : MonoBehaviour
{
    // Start is called before the first frame update    
    List<IEnemyHealthManager> Enemies;
    public int ECNT;
    
    void Start()
    {
        Enemies = gameObject.GetComponentsInChildren<IEnemyHealthManager>().ToList<IEnemyHealthManager>();
        ECNT = Enemies.Count;
        foreach (IEnemyHealthManager enemy in Enemies)
        {
            var roomMan = gameObject.GetComponent<BossRoomMan>();
            enemy.JoinDeath(ref roomMan);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
