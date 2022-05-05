using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    GameObject[] enemies;

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void OnTriggerEnter(Collider co)
    {
        Debug.Log("HIT THE PORTAL");
        if (co.gameObject.tag == "Player" && enemies.Length == 0)
        {
            SceneManager.LoadScene("WIN");
        }
    }
}
