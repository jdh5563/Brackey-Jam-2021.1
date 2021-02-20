using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	public Sprite[] heroUpgrades;
	public GameObject playerHUD;
	private Text allyCount;
	private Text playerHealth;
	private Text playerAttack;
	public int numAllies = 0;
	public int health = 1;
	public int attack = 0;
	private int upgradePoint = 3;

	public GameManager gm;

	// Start is called before the first frame update
	void Start()
	{
		allyCount = playerHUD.transform.GetChild(0).GetComponent<Text>();
		playerHealth = playerHUD.transform.GetChild(1).GetComponent<Text>();
		playerAttack = playerHUD.transform.GetChild(2).GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		allyCount.text = "Allies: " + numAllies;
		playerHealth.text = "Health: " + health;
		playerAttack.text = "Attack: " + attack;

		// Changes the sprite of the hero once enough allies are collected
		// Then spawns the boss and starts a new soundtrack
		if (numAllies == upgradePoint)
		{
			upgradePoint += 1;
			gameObject.GetComponent<SpriteRenderer>().sprite = heroUpgrades[1];
			attack += 1;
			gm.SpawnBoss();
			gm.ChangeAudio();
		}

		// Disables the hero if they run out of health
		if (health <= 0)
		{
			gm.endPanel.transform.GetChild(0).GetComponent<Text>().text =
	"Oh no! Unfortunately you couldn't take down the bug monster this time. Feel free to try again! Thank you so much for playing!";
			gm.endPanel.SetActive(true);
		}
	}
}
