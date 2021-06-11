using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public string Objective;
    public string ShortObj;
    public bool Completed = false;
    public bool inProgress = false;

    public Quest(string _objective,string _shortObj)
    {
        Objective = _objective;
        ShortObj = _shortObj;
    }
    public void Complete() => Completed = false;
}
