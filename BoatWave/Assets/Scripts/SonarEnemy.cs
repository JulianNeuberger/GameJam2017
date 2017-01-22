using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarEnemy : MonoBehaviour {

    public float moveSpeed = 5;
    public float strayFromCenter = 2;
    public float maxDistanceToSonar = 200;

    protected GameObject player;
    new protected Rigidbody2D rigidbody;
    protected AudioSource cry;
    protected Vector2 lastSonar;
    protected bool movingToSonar = false;
    protected Vector2 direction = Vector2.zero;
    protected Vector3 center;
    protected float directionTime = -1;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody = this.GetComponent<Rigidbody2D>();
        player.GetComponent<SonarFallback>().RegisterForSonarEvents(this);
        cry = this.GetComponent<AudioSource>();
        center = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        if(movingToSonar)
        {
            MoveToSonar();
        }
        else
        {
            Wander();
        }
        CheckFlip();
    }

    void MoveToSonar()
    {
        direction = lastSonar - new Vector2(transform.position.x, transform.position.y);
        if (direction.magnitude < .1)
        {
            movingToSonar = false;
        }
        else
        {
            // move in direction of player
            rigidbody.velocity = Vector3.zero;
            // normalize
            direction /= direction.magnitude;
            direction *= moveSpeed;
            rigidbody.velocity = direction;
        }
    }

    void Wander()
    {
        if (directionTime < Time.time)
        {
            directionTime = Time.time + Random.Range(.5f, 3f);
            direction = direction - new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
        Vector2 centerDirection = (center - transform.position);
        if (centerDirection.magnitude > strayFromCenter)
        {
            direction = centerDirection;
        }
        rigidbody.velocity = direction * moveSpeed / 10 / direction.magnitude;
    }

    void CheckFlip()
    {
        if (direction.x != 0)
        {
            if (direction.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public void OnSonar(float x, float y)
    {
        Vector3 sonar = new Vector3(x, y);
        float distanceToSonar = (sonar - transform.position).magnitude;
        if(distanceToSonar < maxDistanceToSonar)
        {
            lastSonar = sonar;
            movingToSonar = true;
            cry.Play();
        }
    }
}
