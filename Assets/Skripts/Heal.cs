using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Skill
{
    int lvlMult;
    int healAmount = 100;

    public Heal(GameObject user) : base(user)
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
        user.GetComponent<Stats>().currentHP = Mathf.Min(user.GetComponent<Stats>().maxHP, user.GetComponent<Stats>().currentHP + healAmount * countMultiplier);
        user.GetComponent<Animator>().SetTrigger("Attack");
    }

}
