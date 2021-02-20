using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
	// Text box and the background panel
	public GameObject introPanel;
	public Text introText;

	// The introductory text for the game
	private string[] intro = {
		"A long time ago in a galaxy far far away,",
		"there were 4 kingdoms in constant turmoil, always wanting to be the strongest.",
		"What they failed to notice was a shadow lurking in the darkness.",
		"Only together could they win this battle.",
		"This is where you come in, Mighty Hero.",
		"Travel to each kingdom, find their greatest warriors, and save us all!"
	};

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine("FadeText");
	}

	// Update is called once per frame
	void Update()
	{

	}

	/// <summary>
	/// Displays the introductory text in segments,
	/// fading in and out of each segment. After all
	/// text is displayed, the background panel is
	/// deactivated.
	/// </summary>
	IEnumerator FadeText()
	{
		introText.canvasRenderer.SetAlpha(0);

		for (int i = 0; i < intro.Length; i++)
		{
			introText.text = intro[i];
			yield return new WaitForSeconds(1f);
			introText.CrossFadeAlpha(1f, 3f, true);
			yield return new WaitForSeconds(5.5f);
			introText.CrossFadeAlpha(0f, 3f, true);
			yield return new WaitForSeconds(3f);
		}

		yield return new WaitForSeconds(0.5f);
		introPanel.SetActive(false);
	}
}
