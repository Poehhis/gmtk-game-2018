using System;
using System.Collections.Generic;
using UnityEngine;

public class ReSpriter : MonoBehaviour
{

	public Class hat;
	public Class shirt;
	public Class hands;

	Dictionary<Class, Sprite[]> sprites;
	SpriteRenderer hatRenderer;
	SpriteRenderer shirtRenderer;
	SpriteRenderer handsRenderer;

	void Start ()
	{
		sprites = new Dictionary<Class, Sprite[]>();
		sprites.Add(Class.WARRIOR, Resources.LoadAll<Sprite>("Sprites/Warrior"));
		sprites.Add(Class.MAGE, Resources.LoadAll<Sprite>("Sprites/Mage"));
		sprites.Add(Class.ARCHER, Resources.LoadAll<Sprite>("Sprites/Archer"));

		SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
		hatRenderer = Array.Find(renderers, it => it.gameObject.name == "Hat");
		shirtRenderer = Array.Find(renderers, it => it.gameObject.name == "Shirt");
		handsRenderer = Array.Find(renderers, it => it.gameObject.name == "Hands");
	}

	void LateUpdate()
	{
		hatRenderer.sprite = Array.Find(sprites[hat], it => it.name == hatRenderer.sprite.name);
		shirtRenderer.sprite = Array.Find(sprites[shirt], it => it.name == shirtRenderer.sprite.name);
		handsRenderer.sprite = Array.Find(sprites[hands], it => it.name == handsRenderer.sprite.name);
	}
}
