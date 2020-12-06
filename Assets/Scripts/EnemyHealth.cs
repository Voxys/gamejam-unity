using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private Animator animator;
    public bool isDead = false;

    public HealthBar healthBar;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("TakeDamage");

        if (currentHealth <= 0)
        {
            Die();
            return;
        }
    }

    public void Die()
    {
        isDead = true;
        animator.SetBool("Dead", true);
        FightManager.instance.LoadWinScene();
        Destroy(healthBar.gameObject);

        return;
    }
}
