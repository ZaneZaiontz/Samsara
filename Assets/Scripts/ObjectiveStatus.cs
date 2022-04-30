using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveStatus : MonoBehaviour
{
    public TextMeshProUGUI numerator;
    int totalEnemies;
    GameObject[] enemies;



    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemies = enemies.Length;
        numerator.text = totalEnemies.ToString() + " / " + totalEnemies.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        numerator.text = (totalEnemies-enemies.Length).ToString() + " / " + totalEnemies.ToString();
    }
}
