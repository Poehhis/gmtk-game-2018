using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warcry : Skill {

    double dmgMulti = 1.33;

    public Warcry(GameObject user) : base(user)
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
        user.GetComponent<Animator>().SetTrigger("Attack");
        user.GetComponent<Stats>().crit = true;
        user.GetComponent<Stats>().critCount = 3;
        user.GetComponent<Stats>().critMulti = dmgMulti;
    }

   
}
