using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Skill
{
    int skillType = 3;
    public int initDmg = 75;

    public Fireball(GameObject user) : base(user)
    {
    }

    public override Class ClassId
    {
        get
        {
            return Class.MAGE;
        }
    }

    public override void Activate(GameObject[] targets)
    {
        targets[0].GetComponent<Stats>().currentHP -= (int)(initDmg * user.GetComponent<Stats>().critMulti);
        targets[0].GetComponent<Stats>().burning = true;
        targets[0].GetComponent<Stats>().burnCounter = 3;
        user.GetComponent<Animator>().SetTrigger("Attack");
    }
}
