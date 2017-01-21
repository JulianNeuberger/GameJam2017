using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarEnemy : MonoBehaviour {

    public float moveSpeed = 100;
    protected GameObject player;
    new protected Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody = this.GetComponent<Rigidbody2D>();
        player.GetComponent<SonarFallback>().RegisterForSonarEvents(this);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnSonar(float x, float y)
    {
        rigidbody.velocity = Vector3.zero;
        Vector3 dir = new Vector3(x, y, this.transform.position.z) - this.transform.position;
        // normalize
        dir /= dir.magnitude;
        dir *= moveSpeed;
        rigidbody.AddForce(dir);
        Debug.Log(dir);
    }
}
