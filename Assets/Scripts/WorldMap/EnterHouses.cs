using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouses : MonoBehaviour
{
    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = GetComponent<PlayerMovement>();

        if (collision.gameObject.CompareTag("House1_Entrance"))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            player.enabled = false;
            SceneManager.LoadScene("House1", LoadSceneMode.Additive);
        }

        if (collision.gameObject.CompareTag("House2_Entrance"))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            player.enabled = false;
            SceneManager.LoadScene("House2", LoadSceneMode.Additive);
        }

        if (collision.gameObject.CompareTag("Shop_Entrance"))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            player.enabled = false;
            SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
        }

        if (collision.gameObject.CompareTag("DungeonLobby_Entrance"))
        {
            player.enabled = false;
            SceneManager.LoadScene("DungeonLobby");
        }

        if (collision.gameObject.CompareTag("Dungeon_Entrance"))
        {
            SceneManager.LoadScene("Dungeon");
            GameManager.Instance.WorldPlayer.transform.position = GameManager.Instance.DungeonSpawnPosition;
        }

        if (collision.gameObject.CompareTag("House1_Exit"))
        {
            SceneManager.UnloadSceneAsync("House1");
            GameManager.Instance.WorldPlayer.GetComponent<PlayerMovement>().enabled = true;
        }

        if (collision.gameObject.CompareTag("House2_Exit"))
        {
            SceneManager.UnloadSceneAsync("House2");
            GameManager.Instance.WorldPlayer.GetComponent<PlayerMovement>().enabled = true;
        }

        if (collision.gameObject.CompareTag("Shop_Exit"))
        {
            SceneManager.UnloadSceneAsync("Shop");
            GameManager.Instance.WorldPlayer.GetComponent<PlayerMovement>().enabled = true;
        }

        if (collision.gameObject.CompareTag("DungeonLobby_Exit"))
        {
            SceneManager.UnloadSceneAsync("DungeonLobby");
            GameManager.Instance.WorldPlayer.GetComponent<PlayerMovement>().enabled = true;

        }

        /*if (collision.gameObject.CompareTag("DungeonDoorExit"))
        {
            SceneManager.UnloadSceneAsync("Dungeon");
            GameManager.Instance.WorldPlayer.GetComponent<PlayerMovement>().enabled = true;
        }*/

    }
}
