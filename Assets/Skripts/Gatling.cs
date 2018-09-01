using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatling : Skill
{
    //skilltype 1=buff/debuff 2=defencive 3=attack
    int skillType = 3;
    public int dmgSingle = 25;   

    public override Class ClassId
    {
        get
        {
            return Class.ARCHER;
        }
    }
    public override void Activate(GameObject[] targets)
    {
        int arrows = Random.Range(3, 6);
        int totalDmg = dmgSingle * arrows;
        targets[0].GetComponent<Stats>().currentHP -= totalDmg;
    }
}
