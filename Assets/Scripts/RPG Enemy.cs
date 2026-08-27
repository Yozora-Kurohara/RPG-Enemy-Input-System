using UnityEngine;

public class RPGEnemy : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] private int maxHealth;

    public string EnemyName => enemyName;
    public int CurrentHealth { get; protected set; }

    protected virtual void Start() 
    {

        CurrentHealth = maxHealth;
    }

    public virtual void PerformAttack(RPGPlayer playerTarget) 
    {

        Debug.Log($"{EnemyName} prepares a basic action.");
    }

    public void TakeDamage(int damage) 
    {
        CurrentHealth -= damage;
        Debug.Log($"{EnemyName} took {damage} damage! Remaining Health: {CurrentHealth}");

        if (CurrentHealth <= 0) Die();
        
    }

    private void Die() 
    {
        Debug.Log($"{EnemyName} has been defeated!");
        Destroy(gameObject);
    }

    public void InstaKill() 
    {
        Debug.Log($"[INSTA-KILL] Ultimate ability activated! {EnemyName} is instantly annihilated!");
        CurrentHealth = 0;
        Die();
    }
}
