using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange_2_3 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("Level 3");
        }
    }

    // Use this for initialization
    // initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
