using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {

    public GameObject hero;
    public GameObject boss;
    int iTurn = 0;
    GameObject[] players;
    ReSpriter reSpriter;

	// Use this for initialization
	void Start () {
        Skill[] skillz = new Skill[] {new Fireball(hero), new PowerSlam(hero), new Gatling(hero),
                                      new Heal(hero), new Sneak(hero), new IronSkin(hero),
                                      new Barrier(hero), new CritBuff(hero), new Warcry(hero) };
        int j = Random.Range(0, 9);
        int k = Random.Range(0, 9);
        int l = Random.Range(0, 9);

        //Skill triples of doubles bonus
        if (j == k && k == l)
        {
            skillz[j].countMultiplier = 3;
            skillz[k].countMultiplier = 3;
            skillz[l].countMultiplier = 3;
        }
        else
        {
            if (j==k)
            {
                skillz[j].countMultiplier = 2;
                skillz[k].countMultiplier = 2;
            }
            if (j==l)
            {
                skillz[j].countMultiplier = 2;
                skillz[l].countMultiplier = 2;
            }
            if (k==l)
            {
                skillz[k].countMultiplier = 2;
                skillz[l].countMultiplier = 2;
            }
        }

        reSpriter = hero.GetComponent<ReSpriter>();
        reSpriter.hat = skillz[j].ClassId;
        reSpriter.shirt = skillz[k].ClassId;
        reSpriter.hands = skillz[l].ClassId;

        hero.GetComponent<Stats>().activeSkills = new Skill[] { new Attack(hero), skillz[j], skillz[k], skillz[l] };
        boss.GetComponent<Stats>().activeSkills = new Skill[] { new Attack(boss) };
        players = new GameObject[2];
        players[0] = hero;
        players[1] = boss;

		StartCoroutine(IntroScene());
	}
	
    public void NextTurn()
    {  
        iTurn = (iTurn + 1) % players.Length;
        players[iTurn].GetComponent<ActionController>().TakeTurn();
    }

	IEnumerator IntroScene()
	{
		hero.GetComponent<Animator>().SetBool("IsWalking", true);

		while(true)
		{
			hero.transform.Translate(Time.deltaTime * 4f, 0f, 0f);

			if (hero.transform.position.x >= -2f)
			{
				hero.GetComponent<Animator>().SetBool("IsWalking", false);
				break;
			}
			yield return null;
		}

		NextTurn();
	}
}
