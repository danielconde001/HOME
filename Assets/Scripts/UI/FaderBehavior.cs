using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderBehavior : MonoBehaviour 
{
	public static FaderBehavior current;

	private int animState = 0;
	public void SetAnimState(int value) {animState = value;}

	private Animator selfAnimator;

	private void Awake()
	{
		current = this;

		selfAnimator = GetComponent<Animator> ();
	}

	private void Update()
	{
		selfAnimator.SetInteger ("animState", animState);
	}
}
