using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSystemShip : HealthSystem {

    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Animator anim;                                              // Reference to the Animator component.
    public AudioSource playerAudio;                                    // Reference to the AudioSource component.
    public Rigidbody2D debrisPrefab;

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
        // playerAudio.clip = deathClip;
        playerAudio.Play();
        // anim.SetTrigger("Die");
        gameObject.GetComponent<PlayerMovement>().Die();

        // spawn debris
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("boot_3_zerstoert");
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        GameObject explosion = ((GameObject)Instantiate(Resources.Load("Explosion")));
        explosion.transform.position = new Vector3(
            gameObject.transform.position.x,
            gameObject.transform.position.y,
            gameObject.transform.position.z + .1f);
        explosion.GetComponent<ParticleSystem>().Play();
        explosion.GetComponent<AudioSource>().Play();
    }
}
