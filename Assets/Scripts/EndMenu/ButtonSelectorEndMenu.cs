using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSelectorEndMenu : MonoBehaviour
{
	public Button RetryBtn;
	public Button QuitBtn;

	void Start()
	{
		Button btnRetry = RetryBtn.GetComponent<Button>();
		Button btnQuit = QuitBtn.GetComponent<Button>();

		btnRetry.onClick.AddListener(Retry);
		btnQuit.onClick.AddListener(Quit);
	}

	void Retry()
	{
		SceneManager.LoadScene("Menu");
		GameManager.Instance.GameRestarted();
	}
	
	void Quit()
    {
		Application.Quit();
    }
}
