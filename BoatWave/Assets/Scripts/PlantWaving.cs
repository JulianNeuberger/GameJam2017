using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWaving : MonoBehaviour {

    public float maxAngle = 5;
    public bool randomizeAngle = true;
    public bool usesWorldPosition = true;
    public static int chachedSinValues = 100;

    protected Quaternion initialRotation;

	// Use this for initialization
	void Start ()
    {
        if (randomizeAngle)
        {
            maxAngle += Random.value * (maxAngle / 2);
        }
        initialRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(30 * Mathf.Sin(Time.time));
        float sinVal = Time.time;
        if(usesWorldPosition)
        {
            sinVal += transform.position.x / 7.5f;
        }
        float sin = Mathf.Sin(sinVal);
        //float sin = GetCachedSin(sinVal);
        float angle = maxAngle * sin;
        transform.rotation = initialRotation * Quaternion.Euler(0, 0, angle);
	}
}
