﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour {

    // Use this for initialization

    public float obstacleDamage = 0.1f;
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if(coll.gameObject.tag == "Player")
		{
            Debug.Log("Zusammenstoß");
			GameObject player = coll.gameObject;
            player.GetComponent<HealtSystemShip>().TakeDamage(obstacleDamage);
		}
        GetComponent<AudioSource>().Play();
	}

}
