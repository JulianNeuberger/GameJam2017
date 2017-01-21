using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 speed = new Vector3();

    public float maxSpeed = 3;
    public float acceleration = 1f;
    public float deAcceleration = 2f;
    public float stopSpeed = 0.001f;
    public bool fixedSpeed;

    public bool debug;

    bool breakButton = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //print("collision: " + collision);
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
            // just so we don't end up with weird behaviour around the zero mark
            if (this.speed.magnitude < this.stopSpeed)
            {
                this.speed.Set(0, 0, 0);
            }

            var tempDirection = direction;
            var tempAccel = acceleration;
            //stop our current acceleration
            if ((breakButton || direction.normalized.magnitude == 0) && this.speed.magnitude > 0)
            {
                if (debug)
                {
                    print("speed: " + this.speed);
                }
                //start decaying
                tempDirection = -speed.normalized;
                tempAccel = deAcceleration;
            }
            if (this.debug)
            {
                print("tempAccel: " + tempAccel);
                print("tempDirection: " + tempDirection);
            }

            this.AddForce(tempDirection * tempAccel);
        }
        else
        {
            this.speed = direction * maxSpeed;
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
        var tempSpeed = speed + acc * Time.deltaTime;

        //make sure we don't fly too fast
        if(tempSpeed.magnitude > maxSpeed)
        {
            tempSpeed.Normalize();
            tempSpeed.Scale(new Vector3(maxSpeed, maxSpeed, maxSpeed));
            if (debug)
            {
                print(tempSpeed);
            }
        }

        speed = tempSpeed;
    }

    void move()
    {
        this.transform.position += speed * Time.deltaTime;
    }

}
