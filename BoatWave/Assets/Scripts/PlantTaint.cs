using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTaint : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        float colorComponent = Random.Range(.9f, 1f);
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.material.color = new Color(
            colorComponent,
            colorComponent,
            colorComponent,
            1);
        renderer.sortingOrder = Random.Range(1, 3);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
