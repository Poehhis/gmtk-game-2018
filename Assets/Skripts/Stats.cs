using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
	public GameObject damageIndicator;
	float lastDITime;

    public bool alive = true;
    public bool shielded = false;

    public bool burning = false;
    public int burnCounter = 0;

    public bool sneak = false;
    public int sneakCounter = 0;

    public bool crit = false;
    public double critMulti = 1;
    public int critCount = 0; 

    //longer count time critical.
    //public bool warcry = false;
    //public int warCounter = 0;

    public bool barrier = false;

    //all init for Armor and handling
    public int maxArm;
    public int _currentArm;
    public int currentArm
    {
        get { return _currentArm; }
        set
        {
            _currentArm = value;
            if (_currentArm <= 0)
            {
                _currentArm = 0;
                shielded = false;
            }
        }
    }

    //all init for HP and handling
    public int maxHP;
    public int _currentHP;
    public int currentHP  
    {
        get { return _currentHP; }
        set
		{
			StartCoroutine(SpawnDI(value - currentHP));
			_currentHP = value;

            if(_currentHP <= 0)
            {
                _currentHP = 0;
                alive = false;
                GetComponent<Animator>().SetTrigger("Die");
                Debug.Log("ded");
            }
        }
    }
    public Skill[] activeSkills;

    private void Start()
    {
        _currentHP = maxHP;
		lastDITime = Time.realtimeSinceStartup;
	}

	IEnumerator SpawnDI(int value)
	{
		while(Time.realtimeSinceStartup - lastDITime < 0.5f)
		{
			yield return null;
		}

		lastDITime = Time.realtimeSinceStartup;
		GameObject di = Instantiate(damageIndicator);
		di.transform.position = new Vector3(transform.position.x, 2.75f, 0f);
		di.GetComponent<DamageIndicatorController>().value = value;
	}
}
