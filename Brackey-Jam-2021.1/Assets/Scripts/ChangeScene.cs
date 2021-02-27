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

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void HelpMenu(GameObject helpMenu)
	{
		helpMenu.SetActive(!helpMenu.activeSelf);
	}

	public void CreditsMenu(GameObject creditsMenu)
	{
		creditsMenu.SetActive(!creditsMenu.activeSelf);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
