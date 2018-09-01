using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseActionButtons : MonoBehaviour
{
    public GameObject button;
    List<GameObject> buttons = new List<GameObject>();
    public void Initialise(Skill[] skills)
    {
        for (int i=0 ; i < skills.Length ; i++)
        {
            GameObject newButton = Instantiate(button);
            newButton.GetComponent<ButtonController>().OnPressed += skills[i].Activate;
            newButton.GetComponent<ButtonController>().spellSlot = "SpellSlot" + (i + 1);
            newButton.transform.position = new Vector3(-4f+i*2, -3f, 1f);
            buttons.Add(newButton);
        }
        
    }
    public void Trash()
    {
        for (int j = 0; j < buttons.Count; j++)
        {
            Destroy(buttons[j]);
        }
        buttons.Clear();
    }
}
