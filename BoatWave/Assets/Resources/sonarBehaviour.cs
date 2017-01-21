using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonarBehaviour : MonoBehaviour {
    Vector3 speed ;    
    float maxspeed = 6f;
   
    int hp = 100;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0)
            Destroy(gameObject);
        hp--;
        /*if (speed.magnitude <= 0.1)
            Destroy(gameObject);
        transform.position += speed * Time.deltaTime;

        //maxspeed = maxspeed / 0.01f;
        //speed = Vector3.ClampMagnitude(speed, maxspeed);
        
        Vector3 friction = new Vector3(speed.x, speed.y);
        float c = 0.05f;
        friction= friction*(-1);
        friction.Normalize();
        friction = friction*(c);
        addForce(friction);
        */       
    }

    void setDir(Vector3 dir)
    {
        speed = Vector3.ClampMagnitude(dir, maxspeed);

       
    }

    void addForce(Vector3 acc)
    {
        speed = speed + acc;
    }
   
}
