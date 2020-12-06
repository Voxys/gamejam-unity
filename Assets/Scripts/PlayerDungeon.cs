using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDungeon : MonoBehaviour
{
    public int RoomBeforeBoss;
    public LevelLoad levelLoader;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "DungeonDoor" && GameManager.Instance.GetNumberOfVisitedRoom() < RoomBeforeBoss)
        {
            GameManager.Instance.IncrementNumberOfVisitedRoom();
            LoadNextLevel();
        }
        else if(collider.gameObject.tag == "DungeonDoor" && GameManager.Instance.GetNumberOfVisitedRoom() >= RoomBeforeBoss)
        {
            LoadBossLevel();
        }

        // Si le joueur collide avec la "sortie et qu'il est dans la première salle"
        if(collider.gameObject.tag == "DungeonDoorExit" && GameManager.Instance.GetNumberOfVisitedRoom() == 0)
        {
            LoadWorldMap();
        }
        else if (collider.gameObject.tag == "DungeonDoorExit" && GameManager.Instance.GetNumberOfVisitedRoom() > 0)
        {
            LoadNextLevel();
            GameManager.Instance.IncrementNumberOfVisitedRoom();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {

            GameManager.Instance.SetActiveScene(SceneManager.GetActiveScene());
            SceneManager.LoadScene("FightScene");
            GameManager.Instance.HideUI();
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene("Assets/Scenes/Dungeon.unity");
    }

    private void LoadBossLevel()
    {
        SceneManager.LoadScene("Assets/Scenes/BossRoom.unity");
    }

    private void LoadWorldMap()
    {
        SceneManager.LoadScene("Assets/Scenes/WorldMapWithoutGameManager&UI.unity");
    }
}
