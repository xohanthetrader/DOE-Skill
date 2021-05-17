using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Unity.Mathematics;
using UnityEngine;

public class FollowManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AIPath toDisable;
    public Transform player;
    public float range;
    public bool inRange;
    
    void Start()
    {
        toDisable.enabled = false;
        StartCoroutine(WaitForSpawn());
    }

    IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(0.3f);
        toDisable.enabled = true;
        print("enabled");
    }

    // Update is called once per frame
    void Update()
    {
       
        if (inRange)
        {
            toDisable.enabled = false;
            GetComponent<PyroAttack>().Attack(player.position,transform.position);
        }
    
        if (!inRange)
        {
            toDisable.enabled = true;
        }
        
        inRange = (player.position - transform.position).sqrMagnitude <= Mathf.Pow(range, 2);
    }
    
    
}
