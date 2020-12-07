using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelector : MonoBehaviour
{
	public Button PlayBtn;
	public Button StoryBtn;

	void Start()
	{
		Button btnPlay = PlayBtn.GetComponent<Button>();
		Button btnStory = StoryBtn.GetComponent<Button>();

		btnPlay.onClick.AddListener(Play);
		btnStory.onClick.AddListener(Story);
	}

	void Play()
	{
		SceneManager.LoadScene("StartScene");
	}

	void Story()
    {
		Debug.Log("story");
    }
}
