using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Image manaBarImage;
    public float CurrentMana;
    public float MaxMana = 100f;
    public PlayerStats player;

    private void Start()
    {
        manaBarImage = GetComponent<Image>();
        player = FindObjectOfType<PlayerStats>();
    }

    public void Update()
    {
        manaBarImage = player.manaBarImage;
        CurrentMana = player.CurrentMana;
        manaBarImage.fillAmount = CurrentMana/MaxMana;
    }
}
