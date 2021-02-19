using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	// A 2D grid that represents the level
	// Static so it can be accessed by other scripts
	public GameObject gridEnd;
	public static GameObject[,] levelGrid;
	public static int levelXBound;
	public static int levelYBound;

	// Things relating to the hero
	public GameObject heroPrefab;
	public GameObject playerHUD;

	// The allies and their sprites
	public GameObject allyPrefab;
	public Sprite[] allySprites;

	// Awake is called before any Start method
	void Awake()
	{
		// Sets the size of the grid to be based on the top right corner
		// tile since the position reflects the grid size minus 1
		levelGrid = new GameObject[(int)gridEnd.transform.position.y + 1, (int)gridEnd.transform.position.x + 1];
		levelXBound = levelGrid.GetLength(1);
		levelYBound = levelGrid.GetLength(0);

		// Creates hero in a random position and attaches camera to them
		GameObject hero = Instantiate(
			heroPrefab,
			new Vector3(Random.Range(0, levelXBound), Random.Range(0, levelYBound), -1),
			Quaternion.identity
			);
		hero.GetComponent<PlayerStats>().playerHUD = playerHUD;
		Camera.main.transform.position = new Vector3(hero.transform.position.x, hero.transform.position.y, -10);
		Camera.main.transform.SetParent(hero.transform);
		levelGrid[(int)hero.transform.position.y, (int)hero.transform.position.x] = hero;

		// Creates allies in random positions
		for (int i = 0; i < 4; i++)
		{
			GameObject ally = Instantiate(
				allyPrefab,
				new Vector3(Random.Range(0, levelXBound), Random.Range(0, levelYBound), -1),
				Quaternion.identity
				);

			ally.GetComponent<SpriteRenderer>().sprite = allySprites[Random.Range(0, allySprites.Length)];

			while (levelGrid[(int)ally.transform.position.y, (int)ally.transform.position.x] != null)
			{
				ally.transform.position = new Vector3(Random.Range(0, levelXBound), Random.Range(0, levelYBound), -1);
			}

			levelGrid[(int)ally.transform.position.y, (int)ally.transform.position.x] = ally;
		}
	}

	// Start is called before the first frame update
	private void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
