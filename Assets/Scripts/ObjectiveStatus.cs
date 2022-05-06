using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveStatus : MonoBehaviour
{
    public TextMeshProUGUI numerator;
    public TextMeshProUGUI leaveScreen;
    int totalEnemies;
    GameObject[] enemies;



    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemies = enemies.Length;
        numerator.text = totalEnemies.ToString() + " / " + totalEnemies.ToString();
        leaveScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        numerator.text = (totalEnemies-enemies.Length).ToString() + " / " + totalEnemies.ToString();
        if (enemies.Length == 0)
        {
            leaveScreen.enabled = true;
        }
    }
}
