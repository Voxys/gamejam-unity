using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSelectorEndMenu : MonoBehaviour
{
	public Button RetryBtn;

	void Start()
	{
		Button btnRetry = RetryBtn.GetComponent<Button>();

		btnRetry.onClick.AddListener(Retry);
	}

	void Retry()
	{
		SceneManager.LoadScene("Menu");
	}
}
