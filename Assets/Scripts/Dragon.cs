using UnityEngine;

public class Dragon : RPGEnemy
{

    public override void PerformAttack(RPGPlayer playerTarget) 
    {
        Debug.Log($"[ENEMY TURN] {EnemyName} opens its jaws and breathes a massive waves of fire!");
        if (playerTarget != null) playerTarget.TakeDamage(35);
    }
    
}
