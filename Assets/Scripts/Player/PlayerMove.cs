using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour 
{
	public static PlayerMove current;
	[SerializeField] private bool canMove = true;
	[SerializeField] private Transform boosterTransform;
	[SerializeField] private float minBoostForce = 25.0f;

	[SerializeField] private float maxBoostForce = 100.0f;
	public float GetMaxBoostForce() {return maxBoostForce;}

	[SerializeField] private float boostForceRate = 100.0f;
	[SerializeField] private float forceMultiplier = 18.0f;
	[SerializeField] private float pitikCutoff = 0.25f;
	[SerializeField] private Animator animator; 
	
	private bool isPitik = true;
	public bool GetIsPitik() {return isPitik;}

	private bool hasMaxedBoost = false;

	private bool isChargingBoost = false;
	public bool GetIsChargingBoost() {return isChargingBoost;}

	private float timer = 0.0f;

	private float currentBoostForce = 0.0f;
	public float GetCurrentBoostForce() {return currentBoostForce;}

	private Rigidbody2D selfRigidbody;

	private void Awake()
	{
		current = this;
		selfRigidbody = GetComponent<Rigidbody2D> ();
	}

	private void Update()
	{
		if (!canMove)
		{
			return;
		}

		if(PlayerStats.current.GetCurrentFuel() > 0)
			Boost ();

		BoosterMove ();

	}

	private void Boost()
	{
		if (Input.GetKey (KeyCode.Mouse1))
		{
			if (timer < pitikCutoff)
				timer += Time.deltaTime;
			else if (timer >= pitikCutoff)
			{
				if(isPitik)
					isPitik = false;
			}
			
			if(!isChargingBoost)
				currentBoostForce = minBoostForce;
			
			isChargingBoost = true;

			if (!hasMaxedBoost) 
			{
				if (currentBoostForce < maxBoostForce) 
				{
					currentBoostForce += boostForceRate * Time.deltaTime;

					if (currentBoostForce > maxBoostForce)
					{
						currentBoostForce = maxBoostForce;
						hasMaxedBoost = true;
					}
				}
			}
			else if (hasMaxedBoost)
			{
				if (currentBoostForce > 0) 
				{
					currentBoostForce -= boostForceRate * Time.deltaTime;

					if (currentBoostForce < minBoostForce) 
					{
						currentBoostForce = minBoostForce;
						hasMaxedBoost = false;
					}
				}
			}
		}

		if (Input.GetKeyUp (KeyCode.Mouse1)) 
		{
			isChargingBoost = false;
			hasMaxedBoost = false;

			if (!isPitik)
				selfRigidbody.linearVelocity = Vector2.zero;
			
			selfRigidbody.AddForce ((-boosterTransform.up * currentBoostForce) * forceMultiplier);
			animator.CrossFadeInFixedTime("Thruster_Thrustloop", 0.01f);
			isPitik = true;
			timer = 0.0f;

			currentBoostForce = 0.0f;
			PlayerStats.current.UseFuel();
		}
	}

	private void BoosterMove()
	{
		Vector3 cursorRawPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 cursorWorldPosition = new Vector3 (cursorRawPosition.x, cursorRawPosition.y, 0.0f);

		boosterTransform.up = -(cursorWorldPosition - transform.position);
	}
}
