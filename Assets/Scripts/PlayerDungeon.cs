using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDungeon : MonoBehaviour
{
    public int RoomBeforeBoss;
    public LevelLoad levelLoader;
    private Vector3 PlayerSpawnPosition; 

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "DungeonDoor" && GameManager.Instance.GetNumberOfVisitedRoom() < RoomBeforeBoss)
        {
            GameManager.Instance.IncrementNumberOfVisitedRoom();
            LoadNextLevel();
        }
        else if(collider.gameObject.tag == "DungeonDoor" || collider.gameObject.tag == "DungeonDoorExit" && GameManager.Instance.GetNumberOfVisitedRoom() >= RoomBeforeBoss)
        {
            LoadBossLevel();
        }

        // Si le joueur collide avec la "sortie et qu'il est dans la première salle"
        if(collider.gameObject.tag == "DungeonDoorExit" && GameManager.Instance.GetNumberOfVisitedRoom() == 0)
        {
            LoadWorldMap();
        }
        else if (collider.gameObject.tag == "DungeonDoorExit" && GameManager.Instance.GetNumberOfVisitedRoom() < RoomBeforeBoss)
        {
            GameManager.Instance.IncrementNumberOfVisitedRoom();
            LoadNextLevel();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {

            GameManager.Instance.SetActiveScene(SceneManager.GetActiveScene());
            SceneManager.LoadScene("FightScene");
            GameManager.Instance.HideUI();
            GameManager.Instance.WorldPlayer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GameManager.Instance.WorldPlayer.GetComponent<PlayerMovement>().enabled = false;
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene("Assets/Scenes/Dungeon.unity");
        GameManager.Instance.WorldPlayer.transform.position = GameManager.Instance.DungeonSpawnPosition;

    }

    private void LoadBossLevel()
    {
        SceneManager.LoadScene("Assets/Scenes/BossRoom.unity");
        GameManager.Instance.WorldPlayer.transform.position =  GameManager.Instance.DungeonSpawnPosition;

    }

    private void LoadWorldMap()
    {
        SceneManager.LoadScene("Assets/Scenes/WorldMapWithoutGameManager&UI.unity");
        GameManager.Instance.WorldPlayer.transform.position = GameManager.Instance.WorldMapSpawnPosition;

    }
}
