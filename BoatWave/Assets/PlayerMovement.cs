﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float maxSpeed = 3;
    public float acceleration = 1f;
    public float deAcceleration = 2f;
    public float stopSpeed = 0.001f;
    public bool fixedSpeed;

    public float maxSoundSpeed = 3;
    public float minSoundSpeed = 1;

    public bool debug;

    bool breakButton = false;
    AudioSource bubbleAudio;
    ParticleSystem bubbleSystem;

    public Rigidbody2D rb;

    void Start()
    {
        bubbleAudio = GetComponent<AudioSource>();
        bubbleSystem = gameObject.transform.Find("Bubbles").GetComponent<ParticleSystem>();

        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //print("collision: " + collision);
        //this.speed.Set(0, 0, 0);
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
            if (this.rb.velocity.magnitude < this.stopSpeed)
            {
                this.rb.velocity.Set(0, 0);
            }

            var tempDirection = direction;
            var tempAccel = acceleration;
            //stop our current acceleration
            if ((breakButton || direction.normalized.magnitude == 0) && this.rb.velocity.magnitude > 0)
            {
                if (debug)
                {
                    print("speed: " + this.rb.velocity);
                }
                //start decaying
                tempDirection = -this.rb.velocity.normalized;
                tempAccel = deAcceleration;
            }
            if (this.debug)
            {
                print("tempAccel: " + tempAccel);
                print("tempDirection: " + tempDirection);
            }

            if (tempDirection.magnitude > 0)
            {
                this.AddForce(tempDirection * tempAccel);
            }
        }
        else
        {
            this.rb.velocity = direction * maxSpeed;
        }

        if (debug)
        {
            print("transform: " + this.transform.position);
            print("speed: " + this.rb.velocity);
        }
        
    }

    void AddForce(Vector2 acc)
    {
        // add the acceleration value
        var tempSpeed = this.rb.velocity + acc * Time.deltaTime;

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

        this.rb.velocity = tempSpeed;

        //update the playback speed of the sound
        {
            float soundSpeed = this.minSoundSpeed;
            if (this.rb.velocity.magnitude > 0) {
                float additionalSpeed = (this.maxSoundSpeed - this.minSoundSpeed) * this.rb.velocity.magnitude / maxSpeed;
                soundSpeed = soundSpeed + additionalSpeed;
            }
            bubbleAudio.pitch = soundSpeed;
        }

    }

}
