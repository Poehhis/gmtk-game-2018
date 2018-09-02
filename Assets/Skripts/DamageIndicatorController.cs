using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicatorController : MonoBehaviour
{
	public int value;

	GameObject textObject;
	Text text;
	
	void Start ()
	{
		textObject = transform.GetChild(0).gameObject;
		text = textObject.GetComponent<Text>();

		text.text = value > 0 ? "+" + value : value.ToString();
		text.color = value >= 0 ? new Color(0f, 0.6f, 0f) : new Color(0.6f, 0f, 0f);
	}
	
	void Update ()
	{
		transform.Translate(0f, Time.deltaTime, 0f);
		text.color -= new Color(0f, 0f, 0f, Time.deltaTime);
		if(text.color.a <= 0)
		{
			Destroy(gameObject);
		}
	}
}
