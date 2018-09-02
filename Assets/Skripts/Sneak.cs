using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sneak : Skill {

    int lvlMult;

    public Sneak(GameObject user) : base(user)
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
        user.GetComponent<Stats>().sneak = true;
        user.GetComponent<Stats>().sneakCounter = 1*countMultiplier;
        user.GetComponent<Animator>().SetTrigger("Attack");
    }

    
}
