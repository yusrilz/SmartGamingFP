using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 5f;
    private float gravity = -9.8f;
    private float jumpHeight = 1f;
    private bool isGrounded;
    // Start is called before the first frame update
    private Vector3 playerVelocity;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    private void FixedUpdate(){
        Move();
        if(Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
    }

    public void Move(){
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0){
            playerVelocity.y = -2f;
        }
        Debug.Log(isGrounded);
        controller.Move(playerVelocity* Time.deltaTime);
    }

    public void Jump(){
        if(isGrounded){
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }
}
