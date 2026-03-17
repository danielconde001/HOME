using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehavior : MonoBehaviour 
{
	public enum SunMovementDirection
	{
		UP,
		DOWN,
		LEFT,
		RIGHT,
		UPLEFT,
		UPRIGHT,
		DOWNLEFT,
		DOWNRIGHT,
		Length
	}

	[SerializeField] private float movementSpeed = 100.0f;
	[SerializeField] private SunMovementDirection movementDirection;

	private void Update()
	{
		Move ();
	}

	private void Move()
	{
		transform.position += (Vector3)(MovementDirection(movementDirection) * movementSpeed) * Time.deltaTime;
	}

	private Vector2 MovementDirection(SunMovementDirection movementDirection)
	{
		return movementDirection == SunMovementDirection.UP ? Vector2.up :
				movementDirection == SunMovementDirection.DOWN ? -Vector2.up :
				movementDirection == SunMovementDirection.LEFT ? -Vector2.right :
				movementDirection == SunMovementDirection.RIGHT ? Vector2.right :
				movementDirection == SunMovementDirection.UPLEFT ? Vector2.ClampMagnitude(Vector2.up - Vector2.right, 1) :
				movementDirection == SunMovementDirection.UPRIGHT ? Vector2.ClampMagnitude(Vector2.up + Vector2.right, 1) :
				movementDirection == SunMovementDirection.DOWNLEFT ? Vector2.ClampMagnitude(-Vector2.up - Vector2.right, 1) :
				movementDirection == SunMovementDirection.DOWNRIGHT ? Vector2.ClampMagnitude(-Vector2.up + Vector2.right, 1) :
				Vector2.zero; 
	}
}
