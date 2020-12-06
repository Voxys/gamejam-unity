using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Villager;

    void Start()
    {
        Instantiate(Villager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
