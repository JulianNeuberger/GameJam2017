using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.A))
        {
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.left);
        }
	}
}
