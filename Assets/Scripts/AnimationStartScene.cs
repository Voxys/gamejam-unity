using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationStartScene : MonoBehaviour
{
    bool HitTheRock = false;


    public AudioClip SeaSound;
    public AudioClip CrashSound;
    public AudioSource AudioSource;

    private void Start()
    {
        AudioSource.PlayOneShot(SeaSound);
    }

    public void FixedUpdate()
    {
        if (!HitTheRock)
        {
            transform.Translate(transform.position.x * -0.1f * Time.deltaTime, 0, 0);
        }
           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.Stop();
        AudioSource.PlayOneShot(CrashSound);
        HitTheRock = true;
        StartCoroutine(LoadScene());

    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1f) ;
        SceneManager.LoadScene("WorldMap");
    }
}
