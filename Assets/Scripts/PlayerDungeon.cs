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
        if(collider.gameObject.tag == "DungeonDoor")
        {
            LoadNextLevel();
            GameManager.Instance.NumberOfVisitedRoom++;
            Debug.Log(GameManager.Instance.NumberOfVisitedRoom);
        }

        /*
        else if(collider.gameObject.tag == "DungeonDoor")
        {
            LoadBossLevel();
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            SceneManager.LoadScene("Assets/Scenes/FightScene.unity");
            Debug.Log("Fight Begin");
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
}
