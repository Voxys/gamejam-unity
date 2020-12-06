using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{

    public GameObject menuGameOver;
    public GameObject menuWin;

    private void Start()
    {
        menuGameOver.SetActive(false);
        menuWin.SetActive(false);
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(WaitBeforeGameOverScene());
    }

    public void LoadWinScene()
    {
        StartCoroutine(WaitBeforeWinScene());
    }

    IEnumerator WaitBeforeGameOverScene()
    {
        yield return new WaitForSeconds(1f);
        menuGameOver.SetActive(true);
    }
    IEnumerator WaitBeforeWinScene()
    {
        yield return new WaitForSeconds(1f);
        menuWin.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.UnloadSceneAsync("FightScene");
    }


    private void ExitTheGame()
    {
        Application.Quit();
    }

    private void Retry()
    {
        // retour au début
        SceneManager.LoadScene("WorldMap");
    }

}
