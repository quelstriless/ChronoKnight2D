using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
      
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        seeker.StartPath(rb.position, new Vector2(target.position.x,target.position.y + 1.5f), OnPathComplete);
    }
    void OnPathComplete(Path p )
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
        if (path == null)
        {
            return;
        }
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        
        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
         
        if(FindObjectOfType<Player>().GetComponent<Transform>().position.x - transform.position.x > 0.4f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(FindObjectOfType<Player>().GetComponent<Transform>().position.x - transform.position.x < 0.4f )
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }


    }

}
