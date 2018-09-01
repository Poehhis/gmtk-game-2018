using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {

    public GameObject hero;
    public GameObject boss;
    int iTurn = 0;
    GameObject[] players;
	// Use this for initialization
	void Start () {
        hero.GetComponent<Stats>().activeSkills = new Skill[] { new Attack(hero), new CritBuff(hero), new Gatling(hero), new Sneak(hero) };
        boss.GetComponent<Stats>().activeSkills = new Skill[] { new Attack(boss) };
        players = new GameObject[2];
        players[0] = hero;
        players[1] = boss;
        NextTurn();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void NextTurn()
    {  
        iTurn = (iTurn + 1) % players.Length;
        players[iTurn].GetComponent<ActionController>().TakeTurn();
    }
}
