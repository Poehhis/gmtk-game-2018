using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour {
    Stats stats;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        float currentHP = transform.parent.parent.GetComponent<Stats>().currentHP / 55f;
        this.transform.localScale = new Vector3(currentHP, this.transform.localScale.y, this.transform.localScale.z);
	}
}
