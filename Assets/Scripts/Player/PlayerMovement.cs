using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float speed = 1.0f;

	private Animator AN_Animator;
	private Rigidbody2D RB_Body;

	public bool FacingLeft = true;
	public bool FacingUp = true;

	private void Awake()
	{
		AN_Animator = GetComponent<Animator>();
		RB_Body = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		AN_Animator.SetFloat("SpeedH", Math.Abs(RB_Body.velocity.x + RB_Body.velocity.y));
	}

	public void Move(float pMoveH, float pMoveV)
	{
		RB_Body.velocity = new Vector2(pMoveH * speed, pMoveV * speed);

		if (pMoveH < 0 && !FacingLeft)
		{
			FlipH();
		}
		else if (pMoveH > 0 && FacingLeft)
		{
			FlipH();
		}

		if (pMoveV < 0 && FacingUp)
		{
			//FlipV();
		}
	}

	private void FlipH()
	{
		FacingLeft = !FacingLeft;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	private void FlipV()
	{
		FacingUp = !FacingUp;

		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		transform.localScale = theScale;
	}
}
