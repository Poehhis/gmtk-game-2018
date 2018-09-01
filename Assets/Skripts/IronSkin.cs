using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronSkin : Skill
{
    double dmgMulti = 0.6; 

    public IronSkin(GameObject user) : base(user)
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
       
        targets[0].GetComponent<Stats>().crit = true;
        targets[0].GetComponent<Stats>().critCount = 3;
        targets[0].GetComponent<Stats>().critMulti = dmgMulti;
        user.GetComponent<Animator>().SetTrigger("Attack");
    }
}
