using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDungeon : MonoBehaviour
{
    public LevelLoad levelLoader;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "DungeonDoor")
        {
            LoadNextLevel();
            //levelLoader.LoadNextLevel();
            Debug.Log("NextRoom");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Debug.Log("Fight Begin");
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene("Assets/Scenes/Dungeon.unity");
    }
}
