using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Image HealthBarImage;
    public float CurrentHealth;
    public float MaxHealth = 100f;
    public PlayerStats player;

    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
        player = FindObjectOfType<PlayerStats>();
    }

    public void Update()
    {
        HealthBarImage = player.healthBarImage;
        CurrentHealth = player.CurrentHealth;
        HealthBarImage.fillAmount = CurrentHealth / MaxHealth;
    }
}
