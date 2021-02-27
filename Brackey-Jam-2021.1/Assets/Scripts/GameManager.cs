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
	private GameObject hero;

	// The allies and their sprites
	public GameObject allyPrefab;
	public Sprite[] allySprites;

	// The enemies and their sprites
	public GameObject enemyPrefab;
	public Sprite bossSprite;
	public Sprite[] enemySprites;

	public AudioClip[] backgroundTracks;

	public GameObject endPanel;

	// Awake is called before any Start method
	void Awake()
	{
		// Sets the size of the grid to be based on the top right corner
		// tile since the position reflects the grid size minus 1
		levelGrid = new GameObject[(int)gridEnd.transform.position.y + 1, (int)gridEnd.transform.position.x + 1];
		levelXBound = levelGrid.GetLength(1);
		levelYBound = levelGrid.GetLength(0);

		SpawnObjects();

		GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
		foreach (GameObject wall in walls)
		{
			levelGrid[(int)wall.transform.position.y, (int)wall.transform.position.x] = wall;
		}
	}

	public void SpawnBoss()
	{
		levelGrid[levelYBound - 2, levelXBound - 2] = Instantiate(enemyPrefab, new Vector3(levelXBound - 2, levelYBound - 1.8f, -1), Quaternion.identity);
		levelGrid[levelYBound - 2, levelXBound - 2].GetComponent<SpriteRenderer>().sprite = bossSprite;
		levelGrid[levelYBound - 2, levelXBound - 2].GetComponent<Enemy>().player = hero;
		levelGrid[levelYBound - 2, levelXBound - 2].GetComponent<Enemy>().moveSpeed = .5f;
		levelGrid[levelYBound - 2, levelXBound - 2].GetComponent<Enemy>().Health = 3;
		levelGrid[levelYBound - 2, levelXBound - 2].name = "Boss";
	}

	public void ChangeAudio()
	{
		gameObject.GetComponent<AudioSource>().clip = backgroundTracks[1];
		gameObject.GetComponent<AudioSource>().Play();
	}

	private void SpawnObjects()
	{
		// Creates hero close to the bottom-left corner and attaches camera to them
		hero = Instantiate(
			heroPrefab,
			new Vector3(1, 2, -1),
			Quaternion.identity
			);
		hero.GetComponent<PlayerStats>().playerHUD = playerHUD;
		hero.GetComponent<PlayerStats>().gm = this;
		Camera.main.transform.position = new Vector3(hero.transform.position.x, hero.transform.position.y, -10);
		Camera.main.transform.SetParent(hero.transform);
		levelGrid[(int)hero.transform.position.y, (int)hero.transform.position.x] = hero;

		// Creates 3 allies around the map for the player to find
		levelGrid[12, 25] = Instantiate(allyPrefab, new Vector3(25, 12, -1), Quaternion.identity);
		levelGrid[12, 25].GetComponent<SpriteRenderer>().sprite = allySprites[Random.Range(0, allySprites.Length)];

		levelGrid[3, 13] = Instantiate(allyPrefab, new Vector3(13, 3, -1), Quaternion.identity);
		levelGrid[3, 13].GetComponent<SpriteRenderer>().sprite = allySprites[Random.Range(0, allySprites.Length)];

		levelGrid[1, 30] = Instantiate(allyPrefab, new Vector3(30, 1, -1), Quaternion.identity);
		levelGrid[1, 30].GetComponent<SpriteRenderer>().sprite = allySprites[Random.Range(0, allySprites.Length)];

		levelGrid[10, 4] = Instantiate(enemyPrefab, new Vector3(4, 10, -1), Quaternion.identity);
		levelGrid[10, 4].GetComponent<SpriteRenderer>().sprite = enemySprites[Random.Range(0, enemySprites.Length)];
		levelGrid[10, 4].GetComponent<Enemy>().player = hero;

		levelGrid[16, 17] = Instantiate(enemyPrefab, new Vector3(17, 16, -1), Quaternion.identity);
		levelGrid[16, 17].GetComponent<SpriteRenderer>().sprite = enemySprites[Random.Range(0, enemySprites.Length)];
		levelGrid[16, 17].GetComponent<Enemy>().player = hero;

		levelGrid[5, 22] = Instantiate(enemyPrefab, new Vector3(22, 5, -1), Quaternion.identity);
		levelGrid[5, 22].GetComponent<SpriteRenderer>().sprite = enemySprites[Random.Range(0, enemySprites.Length)];
		levelGrid[5, 22].GetComponent<Enemy>().player = hero;

		levelGrid[16, 27] = Instantiate(enemyPrefab, new Vector3(27, 16, -1), Quaternion.identity);
		levelGrid[16, 27].GetComponent<SpriteRenderer>().sprite = enemySprites[Random.Range(0, enemySprites.Length)];
		levelGrid[16, 27].GetComponent<Enemy>().player = hero;
	}
}
