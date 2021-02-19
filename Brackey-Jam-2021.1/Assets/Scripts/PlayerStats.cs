using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	public Sprite upgradedHero;
	public GameObject playerHUD;
	private Text allyCount;
	private Text playerHealth;
	public int numAllies = 0;
	public int health = 1;
	private int upgradePoint = 4;

    // Start is called before the first frame update
    void Start()
    {
		allyCount = playerHUD.transform.GetChild(0).GetComponent<Text>();
		playerHealth = playerHUD.transform.GetChild(1).GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
		allyCount.text = "Allies: " + numAllies;
		playerHealth.text = "Health: " + health;
		// Changes the sprite of the hero once enough allies are collected
		if(numAllies == upgradePoint)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = upgradedHero;
		}
    }
}
