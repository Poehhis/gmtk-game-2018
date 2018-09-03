using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public string scene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("SpellSlot3") ||
			(Input.GetMouseButtonDown(0) && Input.touchCount == 0) ||
			(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
		{
			SceneManager.LoadScene(scene);
		}
	}
}
