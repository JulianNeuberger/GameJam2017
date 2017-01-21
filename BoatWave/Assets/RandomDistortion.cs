using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDistortion : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        float r = Random.value;
        if (r < 0.5)
            transform.Find("LightningDistortionRandom").gameObject.SetActive(false);
        if (r < 0.01)
        {
            transform.Find("LightningDistortionRandom").gameObject.SetActive(true);
        }
       
    }
}
