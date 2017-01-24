using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class holeTrigger : MonoBehaviour {

	GameObject objToSpawn;

	// Use this for initialization
	void Start () {
		objToSpawn = new GameObject ("stone");
		objToSpawn.AddComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D coll) 
	{
       
		if(coll.gameObject.tag == "Player")
		{
            //GameObject.Find("RollenderStein").GetComponent<Animator>().SetTrigger("SteinRollt");
            SceneManager.LoadScene("level1_2");
		}
	}
}
