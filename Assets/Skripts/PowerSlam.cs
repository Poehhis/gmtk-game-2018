using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSlam : Skill
{
    int skillType = 3;
    public int swordDmg=100;

    public override Class ClassId
    {
        get
        {
            return Class.WARRIOR;
        }
    }
    public override void Activate(GameObject[] targets)
    {
        targets[0].GetComponent<Stats>().currentHP -= swordDmg;
    }
}
