using UnityEngine;

public class RPGPlayer : MonoBehaviour
{
   [SerializeField] private string playerName = "Hero";
   [SerializeField] private int playerHealth = 120;

    public string PlayerName => playerName;
    public int CurrentHealth { get; private set;  }

    void Awake()
    {
        CurrentHealth = playerHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log($"[PLAYER] {PlayerName} took {damage} damage! Remaining health: {CurrentHealth}");

        if (CurrentHealth <= 0)
        {
            Debug.Log($"[GAME OVER] {PlayerName} has fallen in battle!");

            this.enabled = false;
            Debug.Log($"[SYSTEM] {PlayerName} script has been disabled.");
        }
    }

    public void DisablePlayerScript() 
    {

        this.enabled = false;
        Debug.Log($"[SYSTEM] Battle Won! {PlayerName} script has been disabled.");
    }
}
