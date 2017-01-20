using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{

    Vector3 speed = new Vector3();

    const float MAX_SPEED = 4;
    const float ACCELERATION = 0.1f;

    bool breakButton = false;

    void Update()
    {
        var inputVec = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        inputVec = inputVec.normalized;

        if (Input.GetKeyDown("space"))
        {
            breakButton = true;
        }

        if(Input.GetKeyUp("space"))
        {
            breakButton = false;
        }

        if(breakButton)
        {
            inputVec = -speed.normalized;
        }

        this.AddForce(inputVec * ACCELERATION);

        transform.position += speed * Time.deltaTime;
    }

    void AddForce(Vector3 acc)
    {
        // add the acceleration value
        var tempSpeed = speed + acc;

        //make sure we don't fly too fast
        if(tempSpeed.magnitude > MAX_SPEED)
        {
            setLength(tempSpeed, MAX_SPEED);
        }

        speed = tempSpeed;
    }

    static void setLength(Vector3 vec, double length)
    {
        Vector3 tempVec = vec.normalized;
        tempVec.Set(tempVec.x * MAX_SPEED, tempVec.y * MAX_SPEED, tempVec.z * MAX_SPEED);
        vec.Set(tempVec.x, tempVec.y, tempVec.z);
    }

}
