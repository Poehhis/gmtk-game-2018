using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public delegate void OnPressedHandler(GameObject[] targets);
    public OnPressedHandler OnPressed;
    public string spellSlot;

    TurnController turnController;
    InitialiseActionButtons initialise;
    // Use this for initialization
    void Start () {
        turnController = Camera.main.GetComponent<TurnController>();
        initialise = Camera.main.GetComponent<InitialiseActionButtons>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(spellSlot))
        {
            initialise.Trash();
            OnPressed(new GameObject[] { turnController.boss });
            turnController.NextTurn();

        }
    }
}