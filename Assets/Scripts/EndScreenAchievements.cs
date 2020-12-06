using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenAchievements : MonoBehaviour
{
    public GameObject GoldCounter;
    public GameObject KillCounter;

    private void Awake()
    {
        GoldCounter.GetComponent<Text>().text = "Gold accumulé : " + GameManager.Instance.GetGoldAmount().ToString();
        KillCounter.GetComponent<Text>().text = "Ennemies tués : " + GameManager.Instance.GetKillCounter().ToString();
    }
}
