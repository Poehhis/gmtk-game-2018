using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public bool alive = true;

    public bool burning = false;
    public int burnCounter = 0;

    public bool sneak = false;
    public int sneakCounter = 0;

    public bool crit = false;
    public int critMulti = 1;
    public int critCount = 0; 

    public bool warcry = false;
    public int warCounter = 0;

    public bool barrier = false; 

    public int maxHP;
    public int _currentHP;
    public int currentHP
    {
        get { return _currentHP; }
        set
        {
            _currentHP = value;
            if(_currentHP <= 0)
            {
                alive = false;
            }
        }
    }
    public Skill[] activeSkills;

    

    private void Start()
    {
        currentHP = maxHP;    
    }

}
