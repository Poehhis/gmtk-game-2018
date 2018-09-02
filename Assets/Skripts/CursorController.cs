using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorController : MonoBehaviour
{
	float[] positions = new float[]
	{
		-1.75f, -3.5f
	};

	int index = 0;
	bool pressed = false;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		if (Input.GetAxisRaw("Vertical") > 0 && !pressed)
		{
			pressed = true;
			index = (index + 1) % 2;
			transform.position = new Vector3(0.5f, positions[index], 0f);
		}
		else if (Input.GetAxisRaw("Vertical") < 0 && !pressed)
		{
			pressed = true;
			index--;
			if (index < 0) index = 1;
			transform.position = new Vector3(0.5f, positions[index], 0f);
		}
		else if(Input.GetAxisRaw("Vertical") == 0 && pressed)
		{
			pressed = false;
		}

		if(Input.GetButtonDown("SpellSlot1"))
		{
			if(index == 0)
			{
				SceneManager.LoadScene("1st_lvl");
			}
		}
	}
}
