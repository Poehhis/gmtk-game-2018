using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public delegate void OnPressedHandler(GameObject[] targets);
    public OnPressedHandler OnPressed;
    public string spellSlot;

	public bool activated;

    TurnController turnController;
    InitialiseActionButtons initialise;
    // Use this for initialization
    void Start () {
        turnController = Camera.main.GetComponent<TurnController>();
        initialise = Camera.main.GetComponent<InitialiseActionButtons>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(spellSlot) && !activated)
        {
			initialise.Deactivate();
			StartCoroutine(Active());
        }
    }

	IEnumerator Active()
	{
		while(transform.position.y < -1.75f)
		{
			transform.Translate(0f, Time.deltaTime * 16f, 0f);

			yield return null;
		}
		while (transform.position.y > -2f)
		{
			transform.Translate(0f, -Time.deltaTime * 16f, 0f);

			yield return null;
		}

		yield return new WaitForSeconds(0.5f);

		initialise.Trash();
		OnPressed(new GameObject[] { turnController.boss });
		turnController.NextTurn();
	}
}