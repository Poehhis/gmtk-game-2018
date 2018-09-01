using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warcry : Skill {
    public Warcry(GameObject user) : base(user)
    {
    }

    public override Class ClassId
    {
        get
        {
            return Class.WARRIOR;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void Activate(GameObject[] targets)
    {
        throw new System.NotImplementedException();
    }

   
}
