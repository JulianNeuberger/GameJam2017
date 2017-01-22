using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBehaviour : MonoBehaviour {

    public float colorChange = .01f;

    protected bool moveToSnake = false;
    protected bool lightenUp = false;
    protected GameObject endpoint;
    protected GameObject player;

    // Use this for initialization
    void Start ()
    {
	    endpoint = GameObject.Find("EndPoint");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(lightenUp)
        {
            LightenUp();   
        }	
        if(moveToSnake)
        {
            Vector2 dir = -player.transform.position + endpoint.transform.position;
            if (dir.magnitude < .01f)
            {
                moveToSnake = false;
            }
            else
            {
                dir = dir.normalized * player.GetComponent<PlayerMovement>().maxSpeed;
                player.GetComponent<Rigidbody2D>().velocity = dir;
            }
        }
	}

    void LightenUp()
    {
        Color ambientLight = RenderSettings.ambientLight;
        if (ambientLight.r >= 1)
        {
            lightenUp = false;
        }
        else
        {
            RenderSettings.ambientLight = new Color(
            ambientLight.r + colorChange,
            ambientLight.g + colorChange,
            ambientLight.b + colorChange,
            1);
        }
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.gameObject.tag == "Player")
        {
            // only players can trigger the end sequence
            lightenUp = true;
            moveToSnake = true;
            this.player = player.gameObject;
            player.GetComponent<PlayerMovement>().SetUncontrollable(true);
        }
    }
}