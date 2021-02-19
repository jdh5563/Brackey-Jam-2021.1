using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public Sprite upgradedHero;
	public int numAllies = 0;
	private int upgradePoint = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// Changes the sprite of the hero once enough allies are collected
		if(numAllies == upgradePoint)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = upgradedHero;
		}
    }
}
