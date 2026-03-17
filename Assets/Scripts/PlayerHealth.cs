using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
	public static PlayerHealth current;

	public void Die()
	{
		GetComponent<Animator>().CrossFadeInFixedTime("EarthBoom", 0.01f);
		GameOverManager.current.LoseGame ();
	}

	public void Win()
	{
		GameOverManager.current.WinGame ();
		Destroy (gameObject);
	}

	private void Awake()
	{
		current = this;
	}
}
