using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadTouch : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Player"))
			PlayerHealth.current.Die ();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
			PlayerHealth.current.Die ();
	}
}
