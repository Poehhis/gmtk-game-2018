﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronSkin : Skill
{
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
        throw new System.NotImplementedException();
        user.GetComponent<Animator>().SetTrigger("Attack");
    }
}
