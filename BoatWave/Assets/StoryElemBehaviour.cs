using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryElemBehaviour : MonoBehaviour {

    AudioSource audio;

    Text text;

    bool triggered = false;
    bool played = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        triggered = true;
    }

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
		if(triggered)
        {
            if (!played)
            {
                PlayerMovement movement = GameObject.Find("Player").GetComponent<PlayerMovement>();
                audio.Play();
                movement.displayText(text.text + "");

                played = true;
            }
        }
	}
}
