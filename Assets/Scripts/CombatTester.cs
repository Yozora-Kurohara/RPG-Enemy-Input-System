using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CombatTester : MonoBehaviour
{
    private RPGPlayer player;
    private RPGEnemy goblinTarget;
    private RPGEnemy dragonTarget;


    private bool isPlayerTurn = true;
    private bool isBattleOver = false;

    void Start() 
    {
        player = GameObject.FindAnyObjectByType<RPGPlayer>();
        goblinTarget = GameObject.FindAnyObjectByType<Goblin>();
        dragonTarget = GameObject.FindAnyObjectByType<Dragon>();

        int playerStartingHP = (player != null) ? player.CurrentHealth : 0;

   

        Debug.Log("=== BATTLE START! ===");
        Debug.Log($"[PLAYER STATUS] Initial HP:  {playerStartingHP}");
        Debug.Log("Controls: [1] Attack Goblin | [2] Attack Dragon | [3] Use Ultimate Ability | [4] Reset Battle");
    }

    void Update() 
    {
        if (Keyboard.current != null && Keyboard.current.digit4Key.wasPressedThisFrame) 
        {
            
            Debug.Log("=== COMBAT RESET! ===");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        if (Keyboard.current != null && Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            Debug.Log("=== ULTIMATE ABILITY ACTIVATED! ===");

            if (goblinTarget != null) goblinTarget.InstaKill();
            if (dragonTarget != null) dragonTarget.InstaKill();

            isPlayerTurn = false;
            return;
        }

        if (!isPlayerTurn) return;
        
        if (Keyboard.current != null && Keyboard.current.digit1Key.wasPressedThisFrame)
        {
           ExecutePlayerAttack(goblinTarget);
        }

        if (Keyboard.current != null && Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            ExecutePlayerAttack(dragonTarget);
        }
    }

    void ExecutePlayerAttack(RPGEnemy target)
    {
        if (target != null)
        {
            Debug.Log($"--- Player Turn ---");
            target.TakeDamage(25);

            isPlayerTurn = false;
            Invoke("ExecuteEnemyTurn", 1.5f);

        }
        else 
        {
            Debug.Log("That target is already defeated. Choose another target.");
        }
    }
        public void ExecuteEnemyTurn() 
        {
            
            Debug.Log("--- Enemy Turn ---");

            if (goblinTarget != null) goblinTarget.PerformAttack(player);
            if (dragonTarget != null) dragonTarget.PerformAttack(player);

            if (player != null && player.CurrentHealth > 0) 
            {
                isPlayerTurn = true;
                Debug.Log("=== Your turn!");
            }
        }
   

  
}
