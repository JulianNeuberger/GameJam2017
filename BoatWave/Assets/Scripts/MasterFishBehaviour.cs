using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterFishBehaviour : MonoBehaviour {
    public List<Rigidbody2D> slaveFishPrefabs;
    public float strayFromCenter = 2;
    public int swarmSize = 10;
    public float density = 1.5f;
    public bool useRandomSwarmSize = true; // to implement

    new protected Rigidbody2D rigidbody;
    protected float directionTime = -1;
    protected Vector3 direction = Vector3.zero;
    protected Vector3 center;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        center = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z);
        if(useRandomSwarmSize)
        {
            swarmSize = (int) (swarmSize * Random.Range(.5f, 2));
        }
        Debug.Log(swarmSize);
        for(int i = 1; i < swarmSize; ++i)
        {
            int index = Random.Range(0, slaveFishPrefabs.Count);
            Rigidbody2D slaveFish = Instantiate<Rigidbody2D>(slaveFishPrefabs[index]);
            slaveFish.transform.parent = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (directionTime < Time.time)
        {
            directionTime = Time.time + Random.Range(.5f, 3f);
            direction = new Vector2(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f));
            rigidbody.velocity = direction;
        }
        Vector2 centerDirection = (center - transform.position);
        if (centerDirection.magnitude > strayFromCenter)
        {
            direction = centerDirection;
            rigidbody.velocity = direction;
            //transform.rotation = Quaternion.Euler(direction / direction.magnitude);
        }
    }
}
