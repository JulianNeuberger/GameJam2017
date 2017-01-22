using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayRollingSound()
    {
        PlaySound(0);
    }

    public void PlayCrashSound()
    {
        PlaySound(1);
    }

    protected void PlaySound(int index)
    {
        GetComponents<AudioSource>()[index].Play();
    }
}
