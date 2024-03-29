using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChaseEnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;
    private GameObject player;
    private Transform playerPos;
    private Vector2 currentPos;
    public float distance = 5f;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath(){
        if(seeker.IsDone()) seeker.StartPath(rb.position, target.position, OnPatchComplete);
    }

    void OnPatchComplete(Path p){
        if(!p.error){
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //bool playerdetect = isPlayerDetected();
        /*
        Debug.Log(playerdetect);
        Debug.Log(Vector2.Distance(transform.position, playerPos.position));
        Debug.Log(distance);
        */
        if(path == null) return;
            
        if(currentWaypoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            return;
        }
        else reachedEndOfPath = false;
        //if(playerdetect){

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);
        //transform.position = Vector2.MoveTowards(transform.position, target.position, 3f * Time.deltaTime);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance) currentWaypoint++;
        //}
        //else{
            //transform.position = Vector2.MoveTowards(transform.position, currentPos, 10f * Time.deltaTime);
        //}
    }
    //bool isPlayerDetected(){
        //if(Vector2.Distance(transform.position, playerPos.position) < distance){
            // Debug.Log("masuk");
            //return true;
        //} 
        //else{
            // Debug.Log("keluar");
            //return false;  
        //} 
    //}
}
