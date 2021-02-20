using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// The players position
	private Vector3 position;
	private bool facingLeft = false;

	// Start is called before the first frame update
	void Start()
	{
		position = gameObject.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		// The position of the player last frame
		Vector3 oldPosition = position;

		DetectInput();
		CheckCollisions(oldPosition);

		// Assigns the player to their new grid position
		GameManager.levelGrid[(int)position.y, (int)position.x] = gameObject;

		// Adjusts the actual position of the character
		gameObject.transform.position = position;
	}

	/// <summary>
	/// Moves the player in a direction that
	/// corresponds to the selected input
	/// </summary>
	private void DetectInput()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			GameManager.levelGrid[(int)position.y, (int)position.x] = null;
			position.y += 1;
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			GameManager.levelGrid[(int)position.y, (int)position.x] = null;
			position.y -= 1;
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			GameManager.levelGrid[(int)position.y, (int)position.x] = null;
			position.x += 1;


			if (facingLeft)
			{
				facingLeft = false;
				gameObject.GetComponent<SpriteRenderer>().flipX = false;
			}
		}
		else if (Input.GetKeyDown(KeyCode.A))
		{
			GameManager.levelGrid[(int)position.y, (int)position.x] = null;
			position.x -= 1;

			if (!facingLeft)
			{
				facingLeft = true;
				gameObject.GetComponent<SpriteRenderer>().flipX = true;
			}
		}
	}

	private void CheckCollisions(Vector3 oldPosition)
	{
		// Checks if the new position is occupied
		if (GameManager.levelGrid[(int)position.y, (int)position.x] != null)
		{
			switch (GameManager.levelGrid[(int)position.y, (int)position.x].tag)
			{
				// If there is a wall, don't allow the player to move there
				case "Wall":
					position = oldPosition;
					break;

				// If there is an enemy, both will perform an attack
				// If the enemy is still alive, don't allow the player to move to that tile
				case "Enemy":
					if (GameManager.levelGrid[(int)position.y, (int)position.x].GetComponent<Enemy>().TakeDamage(gameObject.GetComponent<PlayerStats>().attack))
					{
						gameObject.GetComponent<PlayerStats>().health -= GameManager.levelGrid[(int)position.y, (int)position.x].GetComponent<Enemy>().DealDamage();
						GameManager.levelGrid[(int)position.y, (int)position.x].GetComponent<Enemy>().KnockBack((int)(position.y - oldPosition.y), (int)(position.x - oldPosition.x));
						position = oldPosition;
					}
					else
					{
						if (GameManager.levelGrid[(int)position.y, (int)position.x].name == "Boss")
						{
							gameObject.GetComponent<PlayerStats>().gm.endPanel.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text =
								"Congratulations! You defeated the big monster! Thank you so much for playing!";
							gameObject.GetComponent<PlayerStats>().gm.endPanel.SetActive(true);
						}

						Destroy(GameManager.levelGrid[(int)position.y, (int)position.x]);
						GameManager.levelGrid[(int)position.y, (int)position.x] = null;
					}
					break;

				// If there is an ally, destroy it and increment the ally count for the player
				case "Ally":
					gameObject.GetComponent<PlayerStats>().numAllies++;
					gameObject.GetComponent<PlayerStats>().health++;
					Destroy(GameManager.levelGrid[(int)position.y, (int)position.x]);
					break;
			}
		}
	}
}
