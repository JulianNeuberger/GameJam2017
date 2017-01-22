using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
