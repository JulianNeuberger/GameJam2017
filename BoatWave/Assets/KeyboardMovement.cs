using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{

    Vector3 speed = new Vector3();

    public float maxSpeed = 3;
    public float acceleration = 0.1f;
    public float deAcceleration = 0.1f;
    public bool fixedSpeed;

    bool breakButton = false;

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
            //stop our current acceleration
            if (breakButton || direction.normalized.magnitude == 0)
            {
                //start decaying
                tempDirection = -speed.normalized;
            }
            this.AddForce(tempDirection * acceleration);
        } else
        {
            this.speed = direction * maxSpeed;
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
        transform.position += speed * Time.deltaTime;
    }

    static void setLength(Vector3 vec, float length)
    {
        Vector3 tempVec = vec.normalized;
        tempVec.Set(tempVec.x * length, tempVec.y * length, tempVec.z * length);
        vec.Set(tempVec.x, tempVec.y, tempVec.z);
    }

}
