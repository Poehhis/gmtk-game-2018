using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritBuff : Skill
{
    public int critPros;

    public override Class ClassId
    {
        get
        {
            return Class.ARCHER;
        }
    }
    public override void Activate(GameObject[] targets)
    {
        throw new System.NotImplementedException();
    }
}
