using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerBehaviour
{
	[SerializeField]
	public float speed = 1.0f;

	private Animator AN_Animator;
	private Rigidbody2D RB_Body;

	[SerializeField] private ThinkBubble thinkBubleToFlip;
	[SerializeField] private GameObject thinkBubleToMove;

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
		AN_Animator.SetFloat("SpeedV", RB_Body.velocity.y);
	}

	private void Update()
	{
		if (thinkBubleToMove)
		{
			Vector3 bublePosition = thinkBubleToMove.transform.position;
			bublePosition = transform.position;
			thinkBubleToMove.transform.position = bublePosition;
		}
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
	}

	private void FlipH()
	{
		FacingLeft = !FacingLeft;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

		if (thinkBubleToFlip)
		{
			Vector3 bubleScale = thinkBubleToFlip.transform.localScale;
			bubleScale.x *= -1;
			thinkBubleToFlip.transform.localScale = bubleScale;
		}
	}

	public float GetDistanceTo(Vector3 pPos)
	{
		return Utils.GetDistanceFromBox(pPos, boxCollider2D);
	}
}
