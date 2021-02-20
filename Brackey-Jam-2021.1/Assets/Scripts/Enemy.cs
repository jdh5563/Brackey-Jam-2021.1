using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	// Enemy stats
	private int attack = 1;
	private int health = 1;
	private Vector3 position;
	public GameObject player;
	public float moveSpeed = 0.005f;

	public int Health
	{
		get { return health; }

		set { health = value; }
	}

	// Start is called before the first frame update
	void Start()
	{
		position = gameObject.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 oldPosition = position;

		// TODO
		// Fix AI movement
		Move(oldPosition);

		GameManager.levelGrid[(int)position.y, (int)position.x] = gameObject;
		gameObject.transform.position = new Vector3((int)position.x, (int)position.y, (int)position.z);
	}

	private void Move(Vector3 oldPosition)
	{
		GameManager.levelGrid[(int)position.y, (int)position.x] = null;

		if (player.transform.position.x < position.x)
		{
			position.x -= moveSpeed;
		}
		else if (player.transform.position.x > position.x)
		{
			position.x += moveSpeed;
		}

		// Checks if the new position is occupied
		if (GameManager.levelGrid[(int)position.y, (int)position.x] != null)
		{
			switch (GameManager.levelGrid[(int)position.y, (int)position.x].tag)
			{
				// If there is a wall, don't allow the player to move there
				case "Wall":
					position.x = oldPosition.x;
					break;

				// If there is an enemy, both will perform an attack
				// If the enemy is still alive, don't allow the player to move to that tile
				case "Enemy":
					GameManager.levelGrid[(int)position.y, (int)position.x].GetComponent<Enemy>().KnockBack((int)(position.y - oldPosition.y), (int)(position.x - oldPosition.x));
					return;

				// If there is an ally, destroy it and increment the ally count for the player
				case "Ally":
					position.x = oldPosition.x;
					break;
			}
		}

		if (player.transform.position.y < position.y)
		{
			position.y -= moveSpeed;
		}
		else
		{
			position.y += moveSpeed;
		}

		// Checks if the new position is occupied
		if (GameManager.levelGrid[(int)position.y, (int)position.x] != null)
		{
			switch (GameManager.levelGrid[(int)position.y, (int)position.x].tag)
			{
				// If there is a wall, don't allow the player to move there
				case "Wall":
					position.y = oldPosition.y;
					break;

				// If there is an enemy, both will perform an attack
				// If the enemy is still alive, don't allow the player to move to that tile
				case "Enemy":
					GameManager.levelGrid[(int)position.y, (int)position.x].GetComponent<Enemy>().KnockBack((int)(position.y - oldPosition.y), (int)(position.x - oldPosition.x));
					return;

				// If there is an ally, destroy it and increment the ally count for the player
				case "Ally":
					position.y = oldPosition.y;
					break;
			}
		}
	}

	/// <summary>
	/// Deals damage to the enemy
	/// </summary>
	/// <param name="damage">The amount of damage to receive</param>
	/// <returns>True if the enemy is still alive</returns>
	public bool TakeDamage(int damage)
	{
		health -= damage;

		return health > 0;
	}

	/// <summary>
	/// Deals damage to an object
	/// </summary>
	/// <returns>The amount of damage to deal</returns>
	public int DealDamage()
	{
		return attack;
	}

	/// <summary>
	/// Pushes the enemy away from an attacker
	/// </summary>
	/// <param name="yDirection">Up or Down</param>
	/// <param name="xDirection">Left or Right</param>
	public void KnockBack(int yDirection, int xDirection)
	{
		GameManager.levelGrid[(int)position.y, (int)position.x] = null;

		// Push up
		if (yDirection == 1)
		{
			position.y += 4;

			if (position.y > GameManager.levelYBound - 2)
			{
				position.y = GameManager.levelYBound - 2;
			}
		}

		// Push down
		else if (yDirection == -1)
		{
			position.y -= 4;

			if (position.y < 1)
			{
				position.y = 1;
			}
		}

		// Push right
		else if (xDirection == 1)
		{
			position.x += 4;

			if (position.x > GameManager.levelXBound - 2)
			{
				position.x = GameManager.levelXBound - 2;
			}
		}

		// Push left
		else if (xDirection == -1)
		{
			position.x -= 4;

			if (position.x < 1)
			{
				position.x = 1;
			}
		}

		gameObject.transform.position = position;
		GameManager.levelGrid[(int)position.y, (int)position.x] = gameObject;
	}
}
