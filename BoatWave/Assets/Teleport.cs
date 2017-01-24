using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour {
    
    public string key;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(key))
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = this.transform.position;
        }
	}
}
