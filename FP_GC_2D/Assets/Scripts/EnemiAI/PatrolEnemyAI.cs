using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyAI : MonoBehaviour
{
    public float speed;
    public Transform startSpot;
    public Transform finishSpot;
    private  Transform targetSpot;
    void Start()
    {
        targetSpot = finishSpot;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetSpot.position.x, transform.position.y), speed * Time.deltaTime);
        if(transform.position.x == startSpot.position.x){
            targetSpot = finishSpot;
        }
        else if(transform.position.x == finishSpot.position.x){
            targetSpot = startSpot;
        }
        
    }
}
