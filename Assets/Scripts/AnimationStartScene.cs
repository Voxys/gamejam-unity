using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationStartScene : MonoBehaviour
{
    bool HitTheRock = false;

    public void FixedUpdate()
    {
        if (!HitTheRock)
        {
            transform.Translate(transform.position.x * -0.1f * Time.deltaTime, 0, 0);
        }
           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitTheRock = true;
        SceneManager.LoadScene("WorldMap");

    }
}
