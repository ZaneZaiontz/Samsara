using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level01Script : MonoBehaviour
{

    GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.name=="PLAYER" && enemies.Length==0)
        {
            Debug.Log("HIT THE PORTAL");
            SceneManager.LoadScene("Zanes Scene");
        }
    }
}
