﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    Transform target;
    [SerializeField] float speed = 200f;
    [SerializeField] float nextWaypointDistance = 3f;
    Collider2D playercol;
    [SerializeField] Collider2D Enemy;
    [SerializeField]Animator animator;


    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    [SerializeField] Transform enemyGFX;
    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;   
        playercol = player.GetComponentInChildren<Collider2D>();

        Physics2D.IgnoreCollision(playercol, Enemy);    
    }


    void UpdatePath()
    {
        if(seeker.IsDone())
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(path == null)
            return;
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        } else
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

        if(rb.velocity.x >= 0.1f){
            
            enemyGFX.localScale = new Vector3(-3f, 3f, 3f);
        } 
        else if(rb.velocity.x <= -0.1f)
        {
            
            enemyGFX.localScale = new Vector3(3f, 3f, 3f);
        }
        
    }
}
