using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelector : MonoBehaviour
{
	public Button PlayBtn;

	void Start()
	{
		Button btnPlay = PlayBtn.GetComponent<Button>();

		btnPlay.onClick.AddListener(Play);
	}

	void Play()
	{
		SceneManager.LoadScene("StartScene");
	}
}
