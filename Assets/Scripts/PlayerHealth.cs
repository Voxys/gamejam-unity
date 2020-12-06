using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isDead = false;
    public FightManager fightManager;

    public HealthBar healthBar;
    private Animator animator;

    public static PlayerHealth instance;
    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //fightManager.GetComponent<FightManager>();
        animator = GetComponent<Animator>();
        //currentHealth = maxHealth;
        InitHealth();
        healthBar.SetHealth(currentHealth);
        Debug.Log("START");
    }

    private void Update()
    {
        GameManager.Instance.SetPlayerHealth(currentHealth);
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

    public void HealPlayer(int amount)
    {
        if (currentHealth + amount > maxHealth)
            currentHealth = maxHealth;
        else
        {
            currentHealth += amount;
        }
        healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        isDead = true;
        animator.SetBool("Dead", true);
        currentHealth = maxHealth;
        fightManager.LoadGameOverScene();

        return;
    }
    
    public void InitHealth()
    {
        currentHealth = GameManager.Instance.GetPlayerHealth();
        healthBar.SetHealth(currentHealth);
    }

}
