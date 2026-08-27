using UnityEngine;

public class Goblin : RPGEnemy
{

    public override void PerformAttack(RPGPlayer playerTarget) 
    {

        Debug.Log($"[ENEMY TURN] {EnemyName} slashes quickly with a rusty dagger!");
        if (playerTarget != null) playerTarget.TakeDamage(15);
       
    }
    
}
