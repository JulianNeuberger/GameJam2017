using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWaving : MonoBehaviour {

    public float maxAngle = 5;
    public bool randomizeAngle = true;
    public bool usesWorldPosition = true;

	// Use this for initialization
	void Start ()
    {
        if (randomizeAngle)
        {
            this.maxAngle += Random.value * (maxAngle / 2);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(30 * Mathf.Sin(Time.time));
        float sinVal = Time.time;
        if(usesWorldPosition)
        {
            sinVal += transform.position.x / 7.5f;
        }
        float angle = maxAngle * Mathf.Sin(sinVal);
        transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
