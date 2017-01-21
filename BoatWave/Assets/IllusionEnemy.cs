using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionEnemy : MonoBehaviour {

    //we need a collider that is marked as a trigger
    //on the object we assign this to.

    //furthermore, this is expected to have one child Sprite
    //this child Sprite will be faded out gradually
    //and as soon as the fade out is finished
    //the object is removed

    public bool debug;

    GameObject player;

    Color colorStart;
    Color colorEnd;
    public float fadeOutDuration = 1.0f;

    float timePassed = 0;
    bool fadeOut = false;

    Renderer renderer;
    Collider2D collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            collider.enabled = false;
            if (debug)
            {
                print("fading out");
            }
            //start fading out
            fadeOut = true;
        }
    }
    
    void Start () {
        renderer = gameObject.GetComponentInChildren<Renderer>();
        collider = GetComponent<Collider2D>();

        player = GameObject.Find("Player");

        colorStart = renderer.material.color;
        colorEnd = new Color(colorStart.r, colorStart.g, colorStart.b, 0.0f);
    }
	
	void Update () {
        if (fadeOut)
        {
            if (timePassed <= fadeOutDuration)
            {
                timePassed += Time.deltaTime;
                renderer.material.color = Color.Lerp(colorStart, colorEnd, timePassed / fadeOutDuration);
            } else
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
