﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatling : Skill
{
    //skilltype 1=buff/debuff 2=defencive 3=attack
    int lvlMult;
    public int dmgSingle = 25;

    public Gatling(GameObject user) : base(user)
    {
    }

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
        targets[0].GetComponent<Stats>().currentHP -= (int)(totalDmg * user.GetComponent<Stats>().critMulti * countMultiplier);
        user.GetComponent<Animator>().SetTrigger("Attack");
    }
}
