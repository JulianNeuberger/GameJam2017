using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealtSystemShip : HealthSystem {
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    Animator anim;                                              // Reference to the Animator component.
    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    
    void Start () {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        currentHealth = startingHealth;
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
        base.Death();
        print("hier");
        isDead = true;
//        playerAudio.clip = deathClip;
        playerAudio.Play();
        //        anim.SetTrigger("Die");
        //gameObject.GetComponent<PlayerBehaviour>().enabled = false;
        Destroy(gameObject);
    }
}
