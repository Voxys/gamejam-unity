using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    //public GameObject DespawnPoint;
    public int speed = 1;

    private Transform target;


    public void Start()
    {
        target = GameObject.FindWithTag("Checkpoint1").GetComponent<Transform>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Despawn")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Checkpoint1")
        {
            target = GameObject.FindWithTag("Checkpoint2").GetComponent<Transform>();
        }
        else if (collision.gameObject.tag == "Checkpoint2")
        {
            target = GameObject.FindWithTag("Despawn").GetComponent<Transform>();
        }
    }
}
