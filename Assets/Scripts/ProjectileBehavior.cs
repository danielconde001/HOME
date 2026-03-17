using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour 
{
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("ProjectileDie"))
			Destroy (gameObject);
	}
}
