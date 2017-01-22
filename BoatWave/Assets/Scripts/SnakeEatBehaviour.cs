using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEatBehaviour : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GameObject.Find("Snake").GetComponent<Animator>();
        //animator.GetComponent<Animation>().wrapMode = WrapMode.Once;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D player)
    {
        animator.SetTrigger("EatNow");
    }
}
