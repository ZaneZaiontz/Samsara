using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level01Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.name=="PLAYER")
        {
            Debug.Log("HIT THE PORTAL");
            SceneManager.LoadScene("Level02");
        }
    }
}
