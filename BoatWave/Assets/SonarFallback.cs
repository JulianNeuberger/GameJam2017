using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarFallback : MonoBehaviour
{
    // ##################################################
    // vars that can be changed from inspector          #
    // ##################################################

    public float SonarMaxRange      = 50;
    // in units/second
    public float SonarSpeed         = 10; 

    // ##################################################
    // vars hidden from inspector                       #
    // ##################################################

    protected Light Sonar;
    protected bool Pinging;
    protected float SonarIntensity;
    float IntensityChange;

    // Use this for initialization
    void Start ()
    {
        Sonar = GetComponent<Light>();
        SonarIntensity = Sonar.intensity;
        IntensityChange = SonarIntensity / (SonarMaxRange / SonarSpeed);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(!Pinging && Input.GetKeyDown(KeyCode.E))
        {
            Pinging = true;
        }
        if(Pinging)
        {
            if(Sonar.range >= SonarMaxRange)
            {
                Pinging = false;
                Sonar.range = 0;
                Sonar.intensity = SonarIntensity;
            }
            else
            {
                Sonar.range += Time.deltaTime * SonarSpeed;
                Sonar.intensity -= IntensityChange * Time.deltaTime;
            }
        }
	}
}
