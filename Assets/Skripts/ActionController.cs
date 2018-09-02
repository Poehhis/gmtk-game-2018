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
                GameObject newButton = Instantiate(dedScreen);
                
            }

            else if (turnController.hero.GetComponent<Stats>().sneak == true) turnController.NextTurn();

            else
            {

                stats.activeSkills.GetRandomElement().Activate(new GameObject[] { turnController.hero });
                turnController.NextTurn();
            }
        }
        else
        {
            if (turnController.boss.GetComponent<Stats>().alive == false)
            {
                print("You have wonnededed");
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
}
public enum CharacterType
{
    NPC,PLAYER
}