using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomMan : MonoBehaviour,IRoomMan
{
    // Start is called before the first frame update    
    List<IEnemyHealthManager> Enemies;
    public int ECNT;
    
    public int Dead;
    void Start()
    {
        Enemies = gameObject.GetComponentsInChildren<IEnemyHealthManager>().ToList<IEnemyHealthManager>();
        ECNT = Enemies.Count;
        Enemies.ForEach(isBoss);
        foreach (IEnemyHealthManager enemy in Enemies)
        {
            var roomMan = gameObject.GetComponent<IRoomMan>();
            enemy.JoinDeath(ref roomMan);
        }
    }
    void isBoss(IEnemyHealthManager enemy){
        if (enemy.GetType().GetInterfaces().Contains(typeof(IBoss)))
        {
            print(enemy.GetType() + "could be a boss");    
        }
        else
        {
            print(enemy.GetType() + "cant be a boss");
        }
    }
    public void DeathCounter() => Dead++;
    // Update is called once per frame
    void Update()
    {
        
    }
}
