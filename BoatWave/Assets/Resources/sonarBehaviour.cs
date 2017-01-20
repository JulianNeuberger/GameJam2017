using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonarBehaviour : MonoBehaviour {
    Vector3 speed = new Vector3();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var acc = new Vector3(2,0, 0);
        transform.position += acc * Time.deltaTime;
        
    }

    void AddForce(Vector3 acc)
    {
        // add the acceleration value
        var tempSpeed = speed + acc;

        //make sure we don't fly too fast
        
        speed = tempSpeed;
    }
}
