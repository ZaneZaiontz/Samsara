using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float MaxHealth = 100;
    public float CurrentHealth=100;
    public float MaxMana = 100;
    public float CurrentMana=100;

    public Image manaBarImage;
    public Image healthBarImage;

    private void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="EnemyBullet")
        {
            Debug.Log("I've been hit");
            DeductHealth(50);
        }
    }


    public void DeductHealth(float damageAmount)
    {

        CurrentHealth -= damageAmount;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("You Died");
        SceneManager.LoadScene("GameOver");
    }
}
