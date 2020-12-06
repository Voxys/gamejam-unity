using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{

    public GameObject menuGameOver;
    public GameObject menuWin;
    public GameObject[] backgroundList;
    private Scene activeScene;

    private void Awake()
    {
        foreach (var background in backgroundList)
        {
            background.SetActive(false);
        }

        activeScene = SceneManager.GetActiveScene();

        if (activeScene.name == "WorldMap")
            backgroundList[0].SetActive(true);
        if (activeScene.name == "Dungeon")
            backgroundList[1].SetActive(true);
        if (activeScene.name == "BossRoom")
            backgroundList[2].SetActive(true);
        if (activeScene.name == "FightScene")
            backgroundList[1].SetActive(true);
    }

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
