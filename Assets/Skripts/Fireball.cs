using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Skill
{
    public int initDmg = 75;

    public override Class ClassId
    {
        get
        {
            return Class.MAGE;
        }
    }

    public override void Activate(GameObject[] targets)
    {
        targets[0].GetComponent<Stats>().currentHP -= initDmg;
        targets[0].GetComponent<Stats>().burning = true;
        targets[0].GetComponent<Stats>().burnCounter = 3;
    }
}
