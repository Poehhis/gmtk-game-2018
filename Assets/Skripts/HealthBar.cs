using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    Stats stats;
    
    // Use this for initialization
    void Start () {
        stats = transform.parent.GetComponent<Stats>();
    }
	
	// Update is called once per frame
	void Update () {
        
        float hpPro = (float)stats.currentHP / stats.maxHP;
        transform.GetChild(1).localScale = new Vector3 ( hpPro, 1, 1 );

        float armPro = (float)stats.currentArm / stats.maxArm;
        transform.GetChild(2).localScale = new Vector3(armPro, 1, 1);
    }
}
