using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    Vector3 speed = new Vector3();
    float acc = 0f;
    void Update()
    {
        var acc = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        addforce(acc);
        transform.position += speed * Time.deltaTime;
    }

    void addforce(Vector3 acc)
    {
        speed = speed + acc;

    }
}
