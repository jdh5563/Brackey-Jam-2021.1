using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// The players position
	private Vector3 position;

	// The upper bounds of the level
	private int xBound;
	private int yBound;

    // Start is called before the first frame update
    void Start()
    {
		xBound = GameManager.levelGrid.GetLength(1);
		yBound = GameManager.levelGrid.GetLength(0);

		// Sets the initial position of the player to be random
		position = new Vector3(Random.Range(0, xBound), Random.Range(0, yBound), -1);
		gameObject.transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
		// Moves the player in a direction
		// that corresponds to the selected
		// input
		if (Input.GetKeyDown(KeyCode.W) && position.y < yBound - 1)
		{
			position.y += 1;
		}

		if (Input.GetKeyDown(KeyCode.S) && position.y > 0)
		{
			position.y -= 1;
		}

		if (Input.GetKeyDown(KeyCode.D) && position.x < xBound - 1)
		{
			position.x += 1;
		}

		if (Input.GetKeyDown(KeyCode.A) && position.x  > 0)
		{
			position.x -= 1;
		}

		// Adjusts the actual position of the character
		gameObject.transform.position = position;
    }
}
