using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlaveFishBehaviour : MonoBehaviour {

    protected GameObject leader;
    protected Vector2 offset;
    protected float directionTime = -1;
    new protected Rigidbody2D rigidbody;

    // Use this for initialization
    void Start ()
    {
        leader = transform.parent.gameObject;
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 dir = leader.transform.position - transform.position + new Vector3(offset.x, offset.y, 0);
        rigidbody.velocity = dir;

        if (directionTime < Time.time)
        {
            directionTime = Time.time + Random.Range(.5f, 3f);
            offset = new Vector2(
                Random.Range(-1.5f, 1.5f),
                Random.Range(-1.5f, 1.5f)
                );
        }
    }

    public void SetOffset(Vector2 offset)
    {
        this.offset = offset;
    }
}
