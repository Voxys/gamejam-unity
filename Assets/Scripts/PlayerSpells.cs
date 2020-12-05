using System.Collections;
using UnityEngine;

public class PlayerSpells : MonoBehaviour
{
    public int healing = 15;
    public Transform target;
    public float Speed = 4;
    private Animator animator;
    private Vector3 initialePosition;
    private bool isFlipped = false;

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

    }

    IEnumerator Cr_Attack()
    {
        
        while (Mathf.Abs(transform.position.x - target.transform.position.x) > 2.5f)
        {
            animator.SetBool("Run", true);
            transform.Translate(Speed * Time.deltaTime, 0, 0);
            yield return new WaitForEndOfFrame();
            animator.SetBool("Run", false);
        }

        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(0.5f);
        Flip();
        while (Mathf.Abs(transform.position.x - initialePosition.x) > 0.2f)
        {
            animator.SetBool("Run", true);
            transform.Translate(-Speed * Time.deltaTime, 0, 0);
            yield return new WaitForEndOfFrame();
            animator.SetBool("Run", false);
        }
        Flip();

    }

    private void Flip()
    {
        isFlipped = !isFlipped;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }


    public void HealingSpell()
    {
        PlayerHealth.instance.HealPlayer(healing);
    }

}
