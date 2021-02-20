using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}

	public void HelpMenu(GameObject helpMenu)
	{
		helpMenu.SetActive(true);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
