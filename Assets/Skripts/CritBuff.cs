using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritBuff : Skill
{
    int lvlMult;
    int couMult;
    public int dmgMulti = 2;

    public CritBuff(GameObject user) : base(user)
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
        user.GetComponent<Animator>().SetTrigger("Attack");
        user.GetComponent<Stats>().crit = true;
        user.GetComponent<Stats>().critCount = 1;
        user.GetComponent<Stats>().critMulti = dmgMulti*countMultiplier;
    }
}
