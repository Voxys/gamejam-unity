using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{

    public GameObject menuGameOver;
    public GameObject menuWin;
    public GameObject[] backgroundList;
    public GameObject[] DungeonMonsterList;
    public GameObject[] WorldMapMonsterList;
    private string activeScene;
    private Vector3 position;

    public static FightManager instance;

    private void Awake()
    {
        instance = this;
        // Charger le bon bakcground en fonction de la scène active
        // Charger le bon monstre en fonction de la scène active et un peu de hasard
        foreach (var background in backgroundList)
        {
            background.SetActive(false);
        }

        activeScene = GameManager.Instance.GetSceneActive();

        // Map de départ
        if (activeScene == "WorldMap")
        {
            int monster = Random.Range(0, DungeonMonsterList.Length);
            if (monster == 0)
                position = new Vector3(5.23f, -2.17f, 0f);

            Instantiate(WorldMapMonsterList[Random.Range(0, DungeonMonsterList.Length)], position, Quaternion.identity);
            backgroundList[0].SetActive(true);
        }

        // Le donjon
        if (activeScene == "Dungeon")
        {
            backgroundList[1].SetActive(true);
            Instantiate(DungeonMonsterList[Random.Range(0, DungeonMonsterList.Length)], new Vector3(4.41f, -1f, 0), Quaternion.identity);
        }

        // La salle du boss
        if (activeScene == "BossRoom")
            backgroundList[2].SetActive(true);

        // La scène de création et de tests
        if (activeScene == "FightScene")
        {
            backgroundList[2].SetActive(true);
            Instantiate(DungeonMonsterList[Random.Range(0, DungeonMonsterList.Length)], new Vector3(4.41f, -1f, 0), Quaternion.identity);
        }
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
        SceneManager.LoadScene("Dungeon");
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
