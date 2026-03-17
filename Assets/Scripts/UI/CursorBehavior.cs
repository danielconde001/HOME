using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
	public static CursorBehavior current;

	private bool isDisabled = false;
	public void SetIsDisabled(bool value) {isDisabled = value;}

	private Transform playerTransform;

	private Animator selfAnimator;

	private void Awake()
	{
		current = this;
		selfAnimator = GetComponent<Animator>();
		
		Cursor.visible = false;
	}

	private void Start()
	{
		playerTransform = PlayerMove.current.transform;
	}

	private void Update()
	{
		if (!isDisabled)
			Move ();
		else if (isDisabled)
		{
			if (gameObject.activeInHierarchy)
				gameObject.SetActive (false);
		}

		selfAnimator.SetInteger("totalFuel", PlayerStats.current.GetCurrentFuel());
	}

	private void Move()
	{
		transform.position = Input.mousePosition;

		Vector3 playerRawPosition = Camera.main.WorldToScreenPoint (playerTransform.position);
		Vector3 playerScreenPosition = new Vector3 (playerRawPosition.x, playerRawPosition.y, 0.0f);

		transform.up = -(playerScreenPosition - transform.position);
	}
}
