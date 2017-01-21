using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEmitter : MonoBehaviour {
    float maxspeed = 5f;
    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("return"))
        {
            float stepsize = 0.3f;
            for (float i = 0; i < 2 * Mathf.PI; i = i + stepsize)
            {
                GameObject sld = (GameObject)Instantiate(Resources.Load("SonarLightDot"));
                Instantiate(sld);
                Vector3 dir = new Vector3(Mathf.Cos(i), Mathf.Sin(i)) * 100;
                dir = Vector3.ClampMagnitude(dir, maxspeed);
                dir.Normalize();
               
                sld.GetComponent<Rigidbody2D>().position = transform.position+dir*0.25f;
                sld.GetComponent<Rigidbody2D>().velocity = dir*5;
                print(gameObject.transform.position);

                //sld.SendMessage("setDir", new Vector3(Mathf.Cos(i), Mathf.Sin(i)) * 10000);



            }
        }
    }
}
