using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// A 2D grid that represents the level
	// Static so it can be accessed by other scripts
	public GameObject gridEnd;
	public static GameObject[,] levelGrid;

    // Awake is called before any Start method
    void Awake()
    {
		// Sets the size of the grid to be based on the top right corner
		// tile since the position reflects the grid size minus 1
		levelGrid = new GameObject[(int)gridEnd.transform.position.y + 1, (int)gridEnd.transform.position.x + 1];
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
