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
		Screen.sleepTimeout = SleepTimeout.SystemSetting;
	}
	
	void Update ()
	{
		if (Input.GetAxisRaw("Vertical") > 0 && !pressed)
		{
			pressed = true;
			index = (index + 1) % 2;
		}
		else if (Input.GetAxisRaw("Vertical") < 0 && !pressed)
		{
			pressed = true;
			index--;
			if (index < 0) index = 1;
		}
		else if(Input.GetAxisRaw("Vertical") == 0 && pressed)
		{
			pressed = false;
		}

		//Mouse input
		Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (Mathf.Abs(mouse.x - 3f) < 2f && Mathf.Abs(mouse.y + 2.25f) < 0.5f)
		{
			index = 0;
		}
		else if (Mathf.Abs(mouse.x - 3.5f) < 2.5f && Mathf.Abs(mouse.y + 4f) < 0.5f)
		{
			index = 1;
		}
		else
		{
			index = -1;
		}

		if (Input.GetButtonDown("SpellSlot3") || Input.GetMouseButtonDown(0))
		{
			if(index == 0)
			{
				SceneManager.LoadScene("1st_lvl");
			}
			if(index == 1)
			{
				SceneManager.LoadScene("Instructions1");
			}
		}

		if(index >= 0)
		{
			transform.position = new Vector3(0.5f, positions[index], 0f);
		}
		else
		{
			transform.position = new Vector3(mouse.x, mouse.y, 0f);
		}
	}
}
