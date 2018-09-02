using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionController : MonoBehaviour {

    public CharacterType characterType;
    TurnController turnController;
    InitialiseActionButtons initialiseActionButtons;
    Stats stats;
    public GameObject dedScreen;
	public string nextLevel;

	public GameObject credits;
    
    // Use this for initialization
    void Start () {
        turnController = Camera.main.GetComponent<TurnController>();
        initialiseActionButtons = Camera.main.GetComponent<InitialiseActionButtons>();
        stats = GetComponent<Stats>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeTurn()
    {
        //Dead people won't do shit
        if (stats.alive == false)
        {
            turnController.NextTurn();
            return;
        }
        
        //Burning status effect
        if (stats.burning && stats.burnCounter > 0)
        {
            stats.currentHP -= 10;
            stats.burnCounter -= 1;
            if (stats.burnCounter == 0) stats.burning = false;
        }

        //Crit handle
        if (stats.crit && stats.critCount > 0)
        {
            stats.critCount -= 1;
        }
        else
        {
            stats.critMulti = 1;
        }

        //Sneak handle
        if (stats.sneak && stats.sneakCounter > 0)
        {
            stats.sneakCounter -= 1;
        }
        else
        {
            stats.sneak = false;
        }

        //Handling of turns
        if (characterType == CharacterType.NPC)
        {
			if (turnController.hero.GetComponent<Stats>().alive == false)
			{
				print("You have dieded");
				StartCoroutine(DeathScene());
			}
			else
			{
				StartCoroutine(EnemyAttack());
			}
        }
        else
        {
            if (turnController.boss.GetComponent<Stats>().alive == false)
            {
                print("You have wonnededed");
				StartCoroutine(OutroScene());
            }
            else
            {
                initialiseActionButtons.Initialise(GetComponent<Stats>().activeSkills);
            }
        }
        print(GetComponent<Stats>().currentHP);
    }

    void SwapScene(GameObject[] o, string scene)
    {
        SceneManager.LoadScene(scene);
	}

	IEnumerator EnemyAttack()
	{
		yield return new WaitForSeconds(1f);

		if (!turnController.hero.GetComponent<Stats>().sneak)
		{
			stats.activeSkills.GetRandomElement().Activate(new GameObject[] { turnController.hero });

			yield return new WaitForSeconds(0.5f);
		}

		turnController.NextTurn();
	}

	IEnumerator OutroScene()
	{
		yield return new WaitForSeconds(1f);

		if (SceneManager.GetActiveScene().name != "3rd_lvl")
		{
			GetComponent<Animator>().SetBool("IsWalking", true);

			while (true)
			{
				transform.Translate(Time.deltaTime * 4f, 0f, 0f);

				if (transform.position.x >= 11f)
				{
					GetComponent<Animator>().SetBool("IsWalking", false);
					break;
				}
				yield return null;
			}

			SceneManager.LoadScene(nextLevel);
		}
		else
		{
			GetComponent<Animator>().applyRootMotion = false;
			GetComponent<Animator>().SetTrigger("Win");

			yield return new WaitForSeconds(3f);

			Instantiate(credits);
		}
	}

	IEnumerator DeathScene()
	{
		yield return new WaitForSeconds(1f);

		GameObject deathScreen = Instantiate(dedScreen);
		SpriteRenderer sr = deathScreen.GetComponent<SpriteRenderer>();

		while (true)
		{
			sr.color = Color.Lerp(sr.color, new Color(1f, 1f, 1f, 1f), Time.deltaTime);
			yield return null;
		}
	}
}
public enum CharacterType
{
    NPC,PLAYER
}