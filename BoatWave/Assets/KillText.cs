using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillText : MonoBehaviour {

    public float lifeTimeSeconds = 20;
    public float fadeOutTime = 1;

    protected bool fadingOut = false;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        lifeTimeSeconds -= Time.deltaTime;
        if (lifeTimeSeconds < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
