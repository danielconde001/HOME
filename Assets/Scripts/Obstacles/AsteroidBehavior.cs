using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidBehavior : MonoBehaviour
{
	[SerializeField] private GameObject piecesPrefab;
	[SerializeField] private float scatterForce = 10.0f;

	[SerializeField] private UnityEvent OnShot;

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.GetComponent<ProjectileBehavior> () != null) 
		{
			OnShot.Invoke();
		}
	}

	public void Explode()
	{
		GameObject piecesClone = (GameObject)Instantiate (piecesPrefab, transform.position, transform.rotation);

			for(int i = 0; i < piecesClone.transform.childCount; i++)
			{
				GameObject currentChild = piecesClone.transform.GetChild (i).gameObject;
				currentChild.GetComponent<Rigidbody2D> ().AddForce ((currentChild.transform.position - transform.position).normalized * scatterForce);
			}

			piecesClone.transform.DetachChildren ();
			Destroy (piecesClone);
			Destroy (gameObject);
	}
}
