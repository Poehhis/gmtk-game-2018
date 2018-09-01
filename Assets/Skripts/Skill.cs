using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    protected GameObject user;
    public Skill(GameObject user)
    {
        this.user = user;
    }
    public abstract Class ClassId { get; }
    public abstract void Activate(GameObject[] targets);
}

public enum Class
{
    MAGE,ARCHER,WARRIOR,COMMON
}