using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float bossHealth = 300;

    public visualBossHealth bossHealthBar;

    public void Start()
    {
        bossHealthBar.setMaxBossHealth(bossHealth);
        bossHealthBar.setBossHealth(bossHealth);
    }
    public void DeductHealth(float deductHealth)
    {
        bossHealth -= deductHealth;
        bossHealthBar.setBossHealth(bossHealth);
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
