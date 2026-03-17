using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserPlanetBehavior : MonoBehaviour 
{
	[SerializeField] private GameObject geyserEffect;
	[SerializeField] private float waterPushDuration = 3.0f;
	[SerializeField] private float waterPushDelay = 6.0f;

	private Animator animator;

	private bool isEnabled = false;
	private float timer = 0.0f;

	private void Awake()
	{
		geyserEffect.SetActive (false);
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		animator.SetBool("IsEnabled", isEnabled);
		EffectTimer ();
	}

	private void EffectTimer()
	{
		if (isEnabled)
		{
			if(!geyserEffect.activeInHierarchy)
			{
				geyserEffect.SetActive (true);
				//animator.CrossFadeInFixedTime("GyserActivate", 0.01f);
			}

			timer += Time.deltaTime;

			if (timer >= waterPushDuration && geyserEffect.activeInHierarchy)
			{
				//animator.CrossFadeInFixedTime("Gyser", 0.01f);
				geyserEffect.SetActive (false);
			}

			if (timer >= waterPushDelay && isEnabled)
			{
				timer = 0.0f;
				isEnabled = false;
			}
		}
	}


	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.GetComponent<ProjectileBehavior> () != null && !isEnabled) 
			isEnabled = true;
	}
}
