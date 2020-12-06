using System.Collections;
using UnityEngine;

public class EnemySpells : MonoBehaviour
{
    public Transform target;
    public float Speed = 4;
    private Animator animator;
    private Vector3 initialePosition;
    private bool isFlipped = false;
    public bool timeToFight = false;
    public GameObject healthBar;
    public int attackDamage;
    EnemyHealth health;
    private bool isBusy = false;
    public float WaitingTimeAfterAttack;
    public AudioClip Hurt;
    public AudioClip Sword;
    public AudioSource Sound;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        health = GetComponent <EnemyHealth>();
        animator = GetComponent<Animator>();
        initialePosition = transform.position;
    }

    public void Normal_Attack()
    {
        StartCoroutine(Cr_Attack());
    }

    public void Update()
    {
        if (target.gameObject.GetComponent<PlayerSpells>().turn == "Enemy" && health.isDead == false && !isBusy && target.gameObject.GetComponent<PlayerHealth>().currentHealth > 0)
        {
            isBusy = true;
            Normal_Attack();
        }            
    }

    IEnumerator Cr_Attack()
    {
        // pour attendre que le joueur ai fini son sort
        yield return new WaitForSeconds(0.5f);

        while (Mathf.Abs(transform.position.x - target.transform.position.x) > 2.5f)
        {
            healthBar.SetActive(false);
            animator.SetBool("Run", true);
            transform.Translate(-Speed * Time.deltaTime, 0, 0);
            yield return new WaitForEndOfFrame();
            animator.SetBool("Run", false);
        }

        Sound.PlayOneShot(Sword);
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(0.3f);
        Sound.PlayOneShot(Hurt);
        PlayerHealth.instance.TakeDamage(attackDamage);
        yield return new WaitForSeconds(WaitingTimeAfterAttack);

        Flip();
        while (Mathf.Abs(transform.position.x - initialePosition.x) > 0.2f)
        {
            animator.SetBool("Run", true);
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return new WaitForEndOfFrame();
            animator.SetBool("Run", false);
        }
        Flip();
        healthBar.SetActive(true);
        target.gameObject.GetComponent<PlayerSpells>().turn = "Player";
        isBusy = false;

    }

    private void Flip()
    {
        isFlipped = !isFlipped;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void WeakAttack()
    {
        attackDamage /= 2;
    }
}
