using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float bossHealth = 300;

    public void DeductHealth(float deductHealth)
    {
        bossHealth -= deductHealth;

        if (bossHealth <= 0)
        {
            EnemyDead();
        }
    }

    void EnemyDead()
    {
        Destroy(gameObject, .3f);
    }


}
