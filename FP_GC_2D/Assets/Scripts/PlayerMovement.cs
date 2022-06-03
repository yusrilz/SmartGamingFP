using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	// Update is called once per frame
	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("isJumping", true);
		}

		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			crouch = true;
		}
		else if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			crouch = false;
		}
	}

	public void OnLanding()
	{
		animator.SetBool("isJumping", false);
	}

	public void OnCrouching(bool isCrouching)
	{
		animator.SetBool("isCrouching", isCrouching);
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
