﻿using System.Collections;
using UnityEngine;
public class PlayerSpells : MonoBehaviour
{
    public int healing = 15;
    public Transform target;
    public float Speed = 4;
    private Animator animator;
    private Vector3 initialePosition;
    private bool isFlipped = false;
    public int DamageAtt1 = 35;
    public GameObject healingAnimation;
    public GameObject shieldAnimation;
    private int nbShield;
    public int nbMaxShield = 1;
    public string turn = "Player";
    private bool isBusy = false;


    private void Awake()
    {
        nbShield = 0;
        healingAnimation.SetActive(false);
        shieldAnimation.SetActive(false);
        animator = GetComponent<Animator>();
        initialePosition = transform.position;
    }

    public void Update()
    {

    }

    [ContextMenu("Normal Attack")]
    public void Normal_Attack()
    {
        if (isBusy)
            return;

        if (turn == "Player")
        {
            isBusy = true;
            StartCoroutine(Cr_Attack());
        }
    }

    IEnumerator Cr_Attack()
    {

        while (Mathf.Abs(transform.position.x - target.transform.position.x) > 2.5f)
        {
            animator.SetBool("Run", true);
            transform.Translate((transform.position.x < target.transform.position.x ? 1 : -1) * Speed * Time.deltaTime, 0, 0);
            yield return new WaitForEndOfFrame();
            animator.SetBool("Run", false);
        }

        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(0.2f);
        target.GetComponent<EnemyHealth>().TakeDamage(DamageAtt1);
        yield return new WaitForSeconds(0.3f);

        Flip();
        while (Mathf.Abs(transform.position.x - initialePosition.x) > 0.2f)
        {
            animator.SetBool("Run", true);
            transform.Translate((transform.position.x < initialePosition.x ? 1 : -1) * Speed * Time.deltaTime, 0, 0);
            yield return new WaitForEndOfFrame();
            animator.SetBool("Run", false);
        }
        Flip();
        turn = "Enemy";
        isBusy = false;
    }

    private void Flip()
    {
        isFlipped = !isFlipped;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }


    public void HealingSpell()
    {
        if (isBusy)
            return;

        if (turn == "Player")
        {
            isBusy = true;
            PlayerHealth.instance.HealPlayer(healing);
            StartCoroutine(HealingSpellAnim());
        }
    }

    IEnumerator HealingSpellAnim()
    {
        healingAnimation.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        healingAnimation.SetActive(false);
        turn = "Enemy";
        isBusy = false;
    }

    public void ShieldSpell()
    {
        if (isBusy)
            return;

        if (nbShield < nbMaxShield && turn == "Player")
        {
            isBusy = true;
            target.gameObject.GetComponent<GoblinSpells>().WeakAttack();
            StartCoroutine(ShieldSpellAnim());
            nbShield++;
        }
    }

    IEnumerator ShieldSpellAnim()
    {
        shieldAnimation.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        shieldAnimation.SetActive(false);
        turn = "Enemy";
        isBusy = false;
    }

}
