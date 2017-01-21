using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealtSystemShip : HealthSystem {
    Slider healthSlider;                                 // Reference to the UI's health bar.
    Animator anim;                                              // Reference to the Animator component.
    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    
    void Start () {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;

        var canvas = transform.FindChild("Canvas").GetComponent<Canvas>();
        healthSlider = canvas.transform.FindChild("Slider").GetComponent<Slider>();

        healthSlider.value = currentHealth;

        GameObject audioObj = (GameObject) Instantiate(Resources.Load("ShipExplosionSound"));
        playerAudio = audioObj.GetComponent<AudioSource>();
    }	
	// Update is called once per frame
	void Update () {
		
	}
    public override void TakeDamage(float amount)
    {
        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }

    public override void Death()
    {
      
        isDead = true;
//        playerAudio.clip = deathClip;
        playerAudio.Play();
        //        anim.SetTrigger("Die");
        gameObject.GetComponent<PlayerMovement>().Die();
        
    }
}
