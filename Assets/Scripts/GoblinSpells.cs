using System.Collections;
using UnityEngine;

public class GoblinSpells : MonoBehaviour
{
    public Transform target;
    public float Speed = 4;
    private Animator animator;
    private Vector3 initialePosition;
    private bool isFlipped = false;
    public bool timeToFight = false;
    public GameObject healthBar;
    public int attackDamage = 15;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        initialePosition = transform.position;
    }

    public void Normal_Attack()
    {
        StartCoroutine(Cr_Attack());
    }

    public void Update()
    {
        if (timeToFight)
        {
            Normal_Attack();
            timeToFight = false;
        }
            
    }

    IEnumerator Cr_Attack()
    {

        while (Mathf.Abs(transform.position.x - target.transform.position.x) > 2.5f)
        {
            healthBar.SetActive(false);
            animator.SetBool("Run", true);
            transform.Translate(-Speed * Time.deltaTime, 0, 0);
            yield return new WaitForEndOfFrame();
            animator.SetBool("Run", false);
        }

        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(0.3f);
        PlayerHealth.instance.TakeDamage(attackDamage);
        yield return new WaitForSeconds(0.2f);

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

    }

    private void Flip()
    {
        isFlipped = !isFlipped;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
