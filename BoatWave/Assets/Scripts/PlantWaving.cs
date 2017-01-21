using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWaving : MonoBehaviour {

    public float maxAngle = 5;
    public bool randomizeAngle = true;
    public bool usesWorldPosition = true;
    public static int chachedSinValues = 100;
    
    protected static float[] sinValues = new float[chachedSinValues];
    static PlantWaving()
    {
        for(int i = 0; i < chachedSinValues; ++i)
        {
            float sinVal = i * 2 / chachedSinValues;
            sinValues[i] = Mathf.Sin(sinVal);
        }
    }

	// Use this for initialization
	void Start ()
    {
        if (randomizeAngle)
        {
            maxAngle += Random.value * (maxAngle / 2);
        }
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
        transform.rotation = Quaternion.Euler(0, 0, angle);
	}

    static float GetCachedSin(float rad)
    {
        if(rad < 0)
        {
            rad = -1 * rad + 2;
        }
        int index = (int)(rad % 200);
        //Debug.Log(index);
        return sinValues[index];
    }
}
