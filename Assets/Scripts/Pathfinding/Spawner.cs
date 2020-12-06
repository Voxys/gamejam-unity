using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Villager;
    public bool CanSpawn;
    public float SpawnInterval=8f;

    private float m_LastSpawnTime;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time - m_LastSpawnTime >= SpawnInterval)
        {
            m_LastSpawnTime = Time.time;
            Instantiate(Villager);
        }

    }
}
