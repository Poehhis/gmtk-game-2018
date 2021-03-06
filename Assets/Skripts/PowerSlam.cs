﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSlam : Skill
{
    int lvlMult; 
    public int swordDmg=100;

    public PowerSlam(GameObject user) : base(user)
    {
    }

    public override Class ClassId
    {
        get
        {
            return Class.WARRIOR;
        }
    }
    public override void Activate(GameObject[] targets)
    {
        targets[0].GetComponent<Stats>().currentHP -= (int)(swordDmg * user.GetComponent<Stats>().critMulti*countMultiplier);
        user.GetComponent<Animator>().SetTrigger("Attack");
    }
}
