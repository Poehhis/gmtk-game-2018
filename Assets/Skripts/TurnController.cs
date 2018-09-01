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
        Skill[] skillz = new Skill[] {new Fireball(hero), new PowerSlam(hero), new Gatling(hero),
                                      new Heal(hero), new Sneak(hero), new IronSkin(hero),
                                      new Barrier(hero), new CritBuff(hero), new Warcry(hero) };
        int j = Random.Range(0, 9);
        int k = Random.Range(0, 9);
        int l = Random.Range(0, 9);

        hero.GetComponent<Stats>().activeSkills = new Skill[] { new Attack(hero), skillz[j], skillz[k], skillz[l] };
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
