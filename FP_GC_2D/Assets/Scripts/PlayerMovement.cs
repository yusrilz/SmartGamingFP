using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(isGrounded());
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * 5f, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && isGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, 5f);
        }
    }

    private bool isGrounded(){
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }
}
