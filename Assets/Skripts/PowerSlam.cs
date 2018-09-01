using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSlam : Skill
{
    int skillType = 3;
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
        targets[0].GetComponent<Stats>().currentHP -= (swordDmg * user.GetComponent<Stats>().critMulti);
        targets[0].GetComponent<Animator>().SetTrigger("Attack");
    }
}
