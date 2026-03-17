using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodTouch : MonoBehaviour 
{
	private bool gotCapsule = false;
	public void SetGotCapsule(bool value) {gotCapsule = value;}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			if (gotCapsule)
				PlayerHealth.current.Win ();
			else if (!gotCapsule)
				PlayerHealth.current.Die ();
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			if (gotCapsule)
				PlayerHealth.current.Win ();
			else if (!gotCapsule)
				PlayerHealth.current.Die ();
		}
	}
}
