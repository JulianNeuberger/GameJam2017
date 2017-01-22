using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange_Stein : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("level2");
        }
    }

  //Steinanimation wird ausgelöst --> Stein = Leveltür, wenn Triggerzone auf
  //Player trifft wird Levelwechsel ausgeführt
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
