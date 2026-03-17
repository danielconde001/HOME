using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	[SerializeField] private Transform cannonTransform;
	[SerializeField] private Transform cannonEnd;
	[SerializeField] private GameObject bulletProjectile;
	[SerializeField] private float bulletForce = 100.0f;
	[SerializeField] private float knockbackForce = 25.0f;
	[SerializeField] private float forceMultiplier = 18.0f;
	[SerializeField] private float shootDelay = 0.5f;

	private bool readyToShoot = true;
	private float timer = 0.0f;

	private Rigidbody2D selfRigidbody;

	private void Awake()
	{
		selfRigidbody = GetComponent<Rigidbody2D> ();
	}

	private void Update()
	{
		if(PlayerStats.current.GetCurrentFuel() > 0)
			Shoot ();

		CannonMove ();
	}

	private void Shoot()
	{
		if (Input.GetKeyDown (KeyCode.Mouse0) && readyToShoot) 
		{
			GameObject projectileClone = (GameObject)Instantiate (bulletProjectile, cannonEnd.position, Quaternion.Euler(cannonEnd.eulerAngles + new Vector3(0,0,-90)));
			projectileClone.GetComponent<Rigidbody2D> ().AddForce (-(cannonTransform.up * bulletForce) * forceMultiplier);

			selfRigidbody.AddForce ((cannonTransform.up * knockbackForce) * forceMultiplier);
			readyToShoot = false;
			PlayerStats.current.UseFuel();
		}

		if (!readyToShoot)
		{
			timer += Time.deltaTime;

			if (timer > shootDelay) 
			{
				timer = 0.0f;
				readyToShoot = true;
			}
		}
	}

	private void CannonMove()
	{
		Vector3 cursorRawPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 cursorWorldPosition = new Vector3 (cursorRawPosition.x, cursorRawPosition.y, 0.0f);

		cannonTransform.up = -(cursorWorldPosition - transform.position);
	}
}
