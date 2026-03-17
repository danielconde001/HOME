using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBarBehavior : MonoBehaviour 
{
	public static ChargeBarBehavior current;

	[SerializeField] private GameObject chargeBar;
	[SerializeField] private Slider chargeBarSlider;

	private Transform playerTransform;

	private bool isDisabled = false;
	public void SetIsDisabled(bool value) {isDisabled = value;}

	private void Awake()
	{
		//Debug.Log(PlayerMove.current.gameObject.name);
		current = this;
		chargeBar.SetActive (false);
		chargeBarSlider.minValue = 0.0f;
	}

	private void Start()
	{
		playerTransform = PlayerMove.current.transform;
		chargeBarSlider.maxValue = PlayerMove.current.GetMaxBoostForce ();
	}

	private void Update()
	{
		if (!isDisabled) 
		{
			Show ();
			Move ();
		} 
		else if(isDisabled)
		{
			if (chargeBar.activeInHierarchy)
				chargeBar.SetActive (false);
		}
	}

	private void Show()
	{
		if (PlayerMove.current == null)
		{
			return;
		}

		if (PlayerMove.current.GetIsChargingBoost ())
		{
			if (!PlayerMove.current.GetIsPitik())
			{
				if (!chargeBar.activeInHierarchy)
					chargeBar.SetActive (true);

				chargeBarSlider.value = PlayerMove.current.GetCurrentBoostForce ();
			}
		}
		else if (!PlayerMove.current.GetIsChargingBoost ()) 
		{
			if (chargeBar.activeInHierarchy) 
			{
				chargeBar.SetActive (false);
				chargeBarSlider.value = 0.0f;
			}
		}
	}

	private void Move()
	{
		if (playerTransform != null) 
		{
			Vector3 playerRawPosition = Camera.main.WorldToScreenPoint (playerTransform.position);
			Vector3 playerScreenPosition = new Vector3 (playerRawPosition.x, playerRawPosition.y, 0.0f);

			transform.position = playerScreenPosition;

			transform.right = CursorBehavior.current.transform.position - playerScreenPosition;
		}
	}
}
