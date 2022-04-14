using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100;

    public void DeductHealth(float deductHealth)
    {
        enemyHealth -= deductHealth;

        if (enemyHealth <= 0)
        {
            EnemyDead();
        }
    }

    void EnemyDead()
    {
        Destroy(gameObject,.3f);
    }


}
