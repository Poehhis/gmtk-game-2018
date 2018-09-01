using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour {

    public CharacterType characterType;
    TurnController turnController;
    InitialiseActionButtons initialiseActionButtons;
    Stats stats;
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
        //Burning status effect
        if (stats.burning && stats.burnCounter > 0)
        {
            GetComponent<Stats>().currentHP -= 10;
            stats.burnCounter -= 1;
            if (stats.burnCounter == 0) GetComponent<Stats>().burning = false;
        }

        //Handling of turns
        if (characterType == CharacterType.NPC)
        {
            stats.activeSkills.GetRandomElement().Activate(new GameObject[] { turnController.hero });
            turnController.NextTurn();
        }
        else
        {

            initialiseActionButtons.Initialise(GetComponent<Stats>().activeSkills);         
        }
    }
}
public enum CharacterType
{
    NPC,PLAYER
}