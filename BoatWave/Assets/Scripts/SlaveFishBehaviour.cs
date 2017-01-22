using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlaveFishBehaviour : MonoBehaviour {

    public float fleeThreshold = 2;
    public float fleeFactor = 3;

    protected bool fleeing;
    protected GameObject leader;
    protected GameObject player;
    protected MasterFishBehaviour leaderBehaviour;
    protected Vector2 offset;
    protected float directionTime = -1;
    new protected Rigidbody2D rigidbody;
        
    // Use this for initialization
    void Start ()
    {
        leader = transform.parent.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        leaderBehaviour = leader.GetComponent<MasterFishBehaviour>();
        rigidbody = GetComponent<Rigidbody2D>();
        offset = GetRangeOffset();
        transform.position = leader.transform.position + new Vector3(offset.x, offset.y, 0);
        fleeThreshold = fleeThreshold + Random.Range(1f, 2f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 dir;
        Vector2 playerDir = player.transform.position - transform.position;
        if (playerDir.magnitude < fleeThreshold)
        {
            fleeing = true;
        }
        else if(playerDir.magnitude > fleeThreshold * 1.5)
        {
            fleeing = false;
        }
        if(fleeing)
        {
            dir = -playerDir * Mathf.Exp(-playerDir.magnitude/2) * (fleeFactor + Random.Range(1f, 1.5f));
        }
        else
        {
            dir = leader.transform.position - transform.position + new Vector3(offset.x, offset.y, 0);
        }
        rigidbody.velocity = dir;
        //transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan(dir.x / dir.y));
        // flip if swimming left
        if (dir.x != 0)
        {
            if (dir.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }


        if (directionTime < Time.time)
        {
            directionTime = Time.time + Random.Range(.5f, 3f);
            offset = this.GetRangeOffset();
        }
    }

    public void SetOffset(Vector2 offset)
    {
        this.offset = offset;
    }

    public Vector2 GetRangeOffset()
    {
        return new Vector2(
                Random.Range(-leaderBehaviour.density * 1.5f, leaderBehaviour.density * 1.5f),
                Random.Range(-leaderBehaviour.density / 1.5f, leaderBehaviour.density / 1.5f)
                );
    }
}
