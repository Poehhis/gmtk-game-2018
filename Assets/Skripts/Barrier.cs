using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : Skill
{

    public int barrAmount = 100;

    public Barrier(GameObject user) : base(user)
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
        user.GetComponent<Stats>().currentHP += barrAmount;
        user.GetComponent<Animator>().SetTrigger("Attack");
    }
}
