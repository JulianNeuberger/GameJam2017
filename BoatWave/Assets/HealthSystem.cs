using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthSystem : MonoBehaviour {
    public int startingHealth = 1;                            // The amount of health the player starts the game with.
    public float currentHealth;                                   // The current health the player has.
    
    //public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    //public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
       
    protected bool isDead = false;                                                // Whether the player is dead.
    
    // Use this for initialization
    void  Start () {
        // Setting up the references.
        // Set the initial health of the player.
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void TakeDamage(float amount)
    {

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }

    }
    public virtual void Death ()
    {
            // Set the death flag so this function won't be called again.
            isDead = true;
            Destroy(gameObject);
//          playerMovement.enabled = false;
//          playerShooting.enabled = false;
        }
    
}
