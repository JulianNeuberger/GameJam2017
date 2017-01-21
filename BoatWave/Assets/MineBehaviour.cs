using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehaviour : MonoBehaviour {

    protected new ParticleSystem particleSystem;
    protected bool alive = true;
    protected Color color;

    // Use this for initialization
    void Start ()
    {
        particleSystem = GetComponent<ParticleSystem>();
        color = gameObject.GetComponent<SpriteRenderer>().material.color;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!this.alive)
        {
            if(!particleSystem.isPlaying)
            {
                Destroy(this.gameObject);
            }
            color = gameObject.GetComponent<SpriteRenderer>().material.color;
            if (color.a > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().material.color 
                    = new Color(color.r, color.g, color.b, color.a - .1f);
            }
        }


    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(particleSystem != null)
        {
            particleSystem.Play();
            // no more collisions
            GetComponent<Rigidbody2D>().simulated = false;
            alive = false;
        }
    }
}
