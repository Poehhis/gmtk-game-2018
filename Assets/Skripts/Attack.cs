using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Skill
{   //skilltype 1=buff/debuff 2=defencive 3=attack
    int skillType = 3;
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
        targets[0].GetComponent<Stats>().currentHP -= (commonDmg * user.GetComponent<Stats>().critMulti);
        targets[0].GetComponent<Animator>().SetTrigger("Attack");
    }

}
