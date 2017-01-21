using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDistortion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.Find("LightningDistortion").gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        float r = Random.value;
        if (r < 0.5)
            transform.Find("LightningDistortion").gameObject.SetActive(false);
        if (r < 0.01)
        {
            transform.Find("LightningDistortion").gameObject.SetActive(true);
        }
       
    }
}
