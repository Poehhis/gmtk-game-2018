using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Skill
{

    int healAmount;
    public override Class ClassId
    {
        get
        {
            return Class.MAGE;
        }
    }

    public override void Activate(GameObject[] targets)
    {
        
        throw new System.NotImplementedException();
    }

}
