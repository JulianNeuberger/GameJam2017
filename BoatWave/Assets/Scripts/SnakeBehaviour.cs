using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void EatPlayer()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Hide();
    }

    public void FadeToBlack()
    {
        SceneManager.LoadScene("epilogue");
    }
}
