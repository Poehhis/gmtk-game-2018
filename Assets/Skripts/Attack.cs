using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Skill
{
    int lvlMult;
    int couMult;
    int commonDmg = 50;

    public Attack(GameObject user) : base(user)
    {
    }

    //Puttin skill into a class
    public override Class ClassId
    {
        get
        {
            return Class.COMMON;
        }
    }
    
    //what happens when skill is activated
    public override void Activate(GameObject[] targets)
    {
        if (targets[0].GetComponent<Stats>().shielded)
        {
            targets[0].GetComponent<Stats>().currentArm -= (int)(commonDmg * user.GetComponent<Stats>().critMulti);
        }
        else
        {
            targets[0].GetComponent<Stats>().currentHP -= (int)(commonDmg * user.GetComponent<Stats>().critMulti);
        }
        user.GetComponent<Animator>().SetTrigger("Attack");
    }

}
