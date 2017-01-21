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
    protected GameObject SonarEffect;
    protected Color SonarColor;
    protected float IntensityChange;

    // Use this for initialization
    void Start ()
    {
        Sonar = gameObject.transform.Find("Sonar").GetComponent<Light>();
        SonarIntensity = Sonar.intensity;
        IntensityChange = SonarIntensity / (SonarMaxRange / SonarSpeed);
        SonarEffect = Sonar.gameObject.transform.Find("SonarEffect").gameObject;
        SonarColor = SonarEffect.GetComponent<SpriteRenderer>().color;
        SonarEffect.transform.localScale = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(!Pinging && Input.GetKeyDown(KeyCode.E))
        {
            Pinging = true;
        }
        if (Pinging)
        {
            UpdateSonar();
        }
	}

    protected void UpdateSonar()
    {
        if (Sonar.range >= SonarMaxRange)
        {
            // reset the sonar light and effect to inital values
            ResetSonar();
        }
        else
        {
            // sonar "point light"
            Sonar.range += Time.deltaTime * SonarSpeed;
            Sonar.intensity -= Time.deltaTime * IntensityChange;

            // ### sonar effect
            // sonar effect gets larger
            SonarEffect.transform.localScale = new Vector3(Sonar.range, Sonar.range, 1);
            // sonar effects gets more transparent
            float SonarColorAlpha = (1 - Sonar.range / SonarMaxRange) * .25f;
            SonarEffect.GetComponent<SpriteRenderer>().material.color =
                new Color(SonarColor.r, SonarColor.g, SonarColor.b, SonarColorAlpha);
        }
    }

    protected void ResetSonar()
    {
        Pinging = false;
        Sonar.range = 0;
        Sonar.intensity = SonarIntensity;
        SonarEffect.transform.localScale = new Vector3(0, 0, 0);
    }
}
