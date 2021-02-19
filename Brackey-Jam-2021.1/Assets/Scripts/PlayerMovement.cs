using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// The players position
	private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
		position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		// Moves the player in a direction
		// that corresponds to the selected
		// input
		if (Input.GetKeyDown(KeyCode.W) && position.y < GameManager.levelYBound - 1)
		{
			GameManager.levelGrid[(int)position.y, (int)position.x] = null;
			position.y += 1;
		}

		if (Input.GetKeyDown(KeyCode.S) && position.y > 0)
		{
			GameManager.levelGrid[(int)position.y, (int)position.x] = null;
			position.y -= 1;
		}

		if (Input.GetKeyDown(KeyCode.D) && position.x < GameManager.levelXBound - 1)
		{
			GameManager.levelGrid[(int)position.y, (int)position.x] = null;
			position.x += 1;
		}

		if (Input.GetKeyDown(KeyCode.A) && position.x  > 0)
		{
			GameManager.levelGrid[(int)position.y, (int)position.x] = null;
			position.x -= 1;
		}

		// Adds an ally to the player's stats, then destroys the ally
		// that was at the position the player moved to
		if (GameManager.levelGrid[(int)position.y, (int)position.x] != null &&
			GameManager.levelGrid[(int)position.y, (int)position.x].tag == "Ally")
		{
			gameObject.GetComponent<PlayerStats>().numAllies++;
			Destroy(GameManager.levelGrid[(int)position.y, (int)position.x]);
		}

		// Assigns the player to their new grid position
		GameManager.levelGrid[(int)position.y, (int)position.x] = gameObject;

		// Adjusts the actual position of the character
		gameObject.transform.position = position;
    }
}
