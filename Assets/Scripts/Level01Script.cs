using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level01Script : MonoBehaviour
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
        //SceneManager.LoadScene("Zanes Scene");
        if (co.gameObject.tag == "Player" && enemies.Length == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
