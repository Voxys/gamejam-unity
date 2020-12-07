using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelector : MonoBehaviour
{
	public Button PlayBtn;
	public Button StoryBtn;
	public GameObject StoryWindow;

	void Start()
	{
		StoryWindow.SetActive(false);
		Button btnPlay = PlayBtn.GetComponent<Button>();
		Button btnStory = StoryBtn.GetComponent<Button>();

		btnPlay.onClick.AddListener(Play);
		btnStory.onClick.AddListener(Story);
	}

	public void Play()
	{
		SceneManager.LoadScene("StartScene");
	}

	public void Story()
    {
		StoryWindow.SetActive(true);
    }

	public void CloseStory()
	{ 
		StoryWindow.SetActive(false);
	}
}
