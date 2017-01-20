using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{

    Vector3 speed = new Vector3();

    public float maxSpeed = 3;
    public float acceleration = 0.1f;
    public float deAcceleration = 0.1f;
    public float stopSpeed = 0.001f;
    public bool fixedSpeed;

    public bool debug;

    bool breakButton = false;

    void OnCollisionEnter(Collision collision)
    {
        print("collision: " + collision);
        this.speed.Set(0, 0, 0);
    }

    void Update()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        direction = direction.normalized;

        if (Input.GetKeyDown("space"))
        {
            breakButton = true;
        }

        if(Input.GetKeyUp("space"))
        {
            breakButton = false;
        }

        if(!this.fixedSpeed) {
            var tempDirection = direction;
            var tempAccel = acceleration;
            //stop our current acceleration
            if (breakButton || direction.normalized.magnitude == 0)
            {
                //start decaying
                tempDirection = -speed.normalized;
                tempAccel = deAcceleration;
            }
            this.AddForce(tempDirection * tempAccel);
        } else
        {
            this.speed = direction * maxSpeed;
        }

        // just so we don't end up with weird behaviour around the zero mark
        if(this.speed.magnitude < this.stopSpeed)
        {
            this.speed.Set(0, 0, 0);
        }

        if (debug)
        {
            print("transform: " + this.transform.position);
            print("speed: " + this.speed);
        }

        this.move();
    }

    void AddForce(Vector3 acc)
    {
        // add the acceleration value
        var tempSpeed = speed + acc;

        //make sure we don't fly too fast
        if(tempSpeed.magnitude > maxSpeed)
        {
            setLength(tempSpeed, maxSpeed);
        }

        speed = tempSpeed;
    }

    void move()
    {
        this.transform.position += speed * Time.deltaTime;
    }

    static void setLength(Vector3 vec, float length)
    {
        Vector3 tempVec = vec.normalized;
        tempVec.Set(tempVec.x * length, tempVec.y * length, tempVec.z * length);
        vec.Set(tempVec.x, tempVec.y, tempVec.z);
    }

}
