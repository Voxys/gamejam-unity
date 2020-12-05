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
		Button btn = PlayBtn.GetComponent<Button>();
		btn.onClick.AddListener(Play);
	}

	void Play()
	{
		SceneManager.LoadScene("Assets/Scenes/WorldMap.unity");
	}
}
