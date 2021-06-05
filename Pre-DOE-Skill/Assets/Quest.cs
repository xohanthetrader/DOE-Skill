using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public string Objective;
    public bool Completed = false;
    public bool inProgress = false;

    public Quest(string _objective) => Objective = _objective;
    public void Complete() => Completed = false;
}
