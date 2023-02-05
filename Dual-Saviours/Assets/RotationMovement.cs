using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovement : MonoBehaviour
{

	Vector2 moveDir = Vector2.zero;

	public float rotationSpeed = 5f;

	public void StartMoving(Vector2 direction)
	{
		moveDir = direction;
	}

	public void StopMoving()
	{
		moveDir = Vector2.zero;
	}

	private void Update()
	{
		RotateDirection();
	}

	void RotateDirection()
	{
		if (moveDir.sqrMagnitude == 0)
			return;

		moveDir.Normalize();

		transform.Rotate(moveDir, rotationSpeed * Time.deltaTime);
	}

}
