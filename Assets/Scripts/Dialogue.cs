using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject BulleDialogue;
    public GameObject CanvasDialogue;
    public GameObject Dialogue1;
    public GameObject Dialogue2;
    public bool CollideWithPnj;
    public int compteurDialogue;

    void Start()
    {
        BulleDialogue.SetActive(false);
        CanvasDialogue.SetActive(false);
        Dialogue1.SetActive(false);
        Dialogue2.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CollideWithPnj)
        {
            CanvasDialogue.SetActive(true);
            GestionDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CollideWithPnj = true;
            BulleDialogue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            CollideWithPnj = false;
            BulleDialogue.SetActive(false);
            CanvasDialogue.SetActive(false);

            compteurDialogue = 0;
    }

    public void GestionDialogue()
    {
        compteurDialogue++;

        Debug.Log("IsClicked");

        if (compteurDialogue == 1)
        {
            Dialogue1.SetActive(true);
            Dialogue2.SetActive(false);
        }

        if(compteurDialogue == 2)
        {
            Dialogue1.SetActive(false);
            Dialogue2.SetActive(true);
        }

        if(compteurDialogue == 3)
        {
            CanvasDialogue.SetActive(false);
        }
    }
}
