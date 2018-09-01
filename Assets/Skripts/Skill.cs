using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public abstract Class ClassId { get; }
    public abstract void Activate(GameObject[] targets);
}

public enum Class
{
    MAGE,ARCHER,WARRIOR,COMMON
}