using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public bool alive = true;

    public bool burning = false;
    public int burnCounter = 0;

    public bool sneak = false;
    public bool crit = false;
    public bool warcry = false;
    public bool barrier = false; 

    public int maxHP;
    public int currentHP;
    public Skill[] activeSkills;

    

private void Start()
    {
        currentHP = maxHP;    
    }
    
}
