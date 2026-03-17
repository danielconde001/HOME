using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsPanelBehavior : MonoBehaviour 
{
	public static NewsPanelBehavior current;

	[SerializeField] private Button yesButton;
	[SerializeField] private Button noButton;

	private int animState = 0;
	public void SetAnimState(int value) {animState = value;}

	private Animator selfAnimator;

	private void Awake()
	{
		current = this;

		selfAnimator = GetComponent<Animator> ();
	}

	private void Start()
	{
		yesButton.onClick.AddListener (GameOverManager.current.RestartGame);
	}

	private void Update()
	{
		selfAnimator.SetInteger ("animState", animState);
	}
}
