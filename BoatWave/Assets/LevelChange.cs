using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") ;
        {
            SceneManager.LoadScene("Level 1");
        }
    }

    // Use this for initialization
   // initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
