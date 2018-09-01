using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseActionButtons : MonoBehaviour
{
    public GameObject button;
    List<GameObject> buttons = new List<GameObject>();

    public Sprite attackSprite;
    public Sprite fbSprite;
    public Sprite psSprite;
    public Sprite barrageSprite;
    public Sprite sneakSprite;
    public Sprite focusSprite;
    public Sprite barrierSprite;
    public Sprite healSprite;
    public Sprite ironskinSprite;
    public Sprite warcrySprite;

    public void Initialise(Skill[] skills)
    {
        Color[] colors = new Color[]
        {
            new Color(0.2f, 1f, 0.6f),
            new Color(0.2f, 0.6f, 1f),
            new Color(1f, 0.6f, 0.2f),
            new Color(1f, 0.2f, 0.6f)
        };

        for (int i=0 ; i < skills.Length ; i++)
        {
            GameObject newButton = Instantiate(button);
            newButton.GetComponent<ButtonController>().OnPressed += skills[i].Activate;
            newButton.GetComponent<ButtonController>().spellSlot = "SpellSlot" + (i + 1);
            newButton.transform.position = new Vector3(-3f+i*2, -3f, 1f);

            SpriteRenderer sr = newButton.transform.GetChild(0).GetComponent<SpriteRenderer>();
            if (skills[i].GetType() == typeof(Fireball)) sr.sprite = fbSprite;
            if (skills[i].GetType() == typeof(Attack)) sr.sprite = attackSprite;
            if (skills[i].GetType() == typeof(PowerSlam)) sr.sprite = psSprite;
            if (skills[i].GetType() == typeof(Gatling)) sr.sprite = barrageSprite;
            if (skills[i].GetType() == typeof(Heal)) sr.sprite = healSprite;
            if (skills[i].GetType() == typeof(Barrier)) sr.sprite = barrierSprite;
            if (skills[i].GetType() == typeof(Sneak)) sr.sprite = sneakSprite;
            if (skills[i].GetType() == typeof(CritBuff)) sr.sprite = focusSprite;
            if (skills[i].GetType() == typeof(IronSkin)) sr.sprite = ironskinSprite;
            if (skills[i].GetType() == typeof(Warcry)) sr.sprite = warcrySprite;

            sr.color = colors[i];
            
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
