using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMonsterManager : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float seeingDistance;

    private AudioSource Sound;
    private Transform target;

    void Start()
    {
        Sound = GetComponent<AudioSource>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position,target.position)>stoppingDistance && Vector2.Distance(transform.position, target.position) < seeingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if(Vector2.Distance(transform.position, target.position) > seeingDistance)
        {
            PlaySound();
        }
    }

    private void PlaySound()
    {
        Sound.Play();
    }
}
