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
            player.enabled = false;
            SceneManager.LoadScene("House1", LoadSceneMode.Additive);
        }

        if (collision.gameObject.CompareTag("House1_Exit"))
        {
            SceneManager.UnloadSceneAsync("House1");
            GameManager.Instance.WorldPlayer.GetComponent<PlayerMovement>().enabled = true;
        }
    }
}
