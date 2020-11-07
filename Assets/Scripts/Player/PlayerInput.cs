using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
	private PlayerMovement movement;

	private void Awake()
	{
		movement = GetComponent<PlayerMovement>();
	}

	private void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		movement.Move(h, v);
	}
}
